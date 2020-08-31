using dotNetAssignment.DataEntities;
using dotNetAssignment.Models;
using dotNetAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dotNetAssignment.Services
{
    public class ContractsService : IContractsService
    {

        private readonly IRepository<Contracts> _contractsRepository;
        private readonly IRepository<RateChart> _rateChartRepository;
        private readonly IRepository<CoveragePlan> _coveragePlanRepository;
        private readonly IRepository<Rules> _rulesRepository;
        private readonly IRepository<ContractsView> _contractsViewRepository;

        public ContractsService(IRepository<Contracts> _contractsRepository,
                                IRepository<RateChart> _rateChartRepository,
                                IRepository<CoveragePlan> _coveragePlanRepository,
                                IRepository<Rules> _rulesRepository,
                                IRepository<ContractsView> _contractsViewRepository)
        {
            this._contractsRepository = _contractsRepository;
            this._rateChartRepository = _rateChartRepository;
            this._coveragePlanRepository = _coveragePlanRepository;
            this._rulesRepository = _rulesRepository;
            this._contractsViewRepository = _contractsViewRepository;
        }

        public void DeleteContract(int id)
        {
            _contractsRepository.Delete(_contractsRepository.Get(id));
        }

        public Contracts GetContract(int id)
        {
            return _contractsRepository.Get(id);
        }

        public IEnumerable<Contracts> GetContracts()
        {
            return _contractsRepository.GetAll().ToList();
        }

        private int GetCoveragePlan(int country)
        {
            var coveragePlan = _coveragePlanRepository.GetQueryables().Where(x => x.EligCountry == country);
            if (coveragePlan != null && coveragePlan.Count() > 0)
            {
                return coveragePlan.First().Id;
            }
            else
            {
                throw new Exception("There are no coverage plans available for this country.");
            }
        }

        private int GetRateChartId(int coveragePlan, int age, int gender)
        {
            //Get all the rates that has the selected coveragePlan.
            var ratesAccordingToPlan = _rateChartRepository.GetQueryables().Where(x => x.CoveragePlan == coveragePlan).ToList();
            if (ratesAccordingToPlan != null)
            {
                //Get all the plans for the given gender.
                var ratesAccordingToGender = ratesAccordingToPlan.FindAll(x => x.CustomerGender == gender);
                if (ratesAccordingToGender != null)
                {
                    //From the rate list, find the most suitable one with the help of customer age and rate conditional age.
                    foreach (var rate in ratesAccordingToGender)
                    {
                        var ageConditionRule = _rulesRepository.Get(rate.AppliedRule);
                        if (ageConditionRule != null)
                        {
                            if (ValidateRate(rate.CustomerGender, ageConditionRule, age, gender, rate.Age))
                            {
                                return rate.Id;
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid rule");
                        }
                    }
                    throw new Exception("Contract rate not found");
                }
                else
                {
                    throw new Exception("Invalid gender");
                }
            }
            else
            {
                throw new Exception("This coverage plan is not available. Please select a valid coverage plan");
            }
        }

        private bool ValidateRate(int rateGender, Rules rule, int age, int gender, int conditionalAge)
        {
            if (rateGender == gender)
            {
                var result = new DataTable().Compute($"{age}{rule.RuleText}{conditionalAge}", null);
                return (bool)result;
            }
            else
            {
                return false;
            }
        }

        public void InsertContract(CustomerDto customerDto)
        {
            var age = CalculateAge(customerDto.DateOfBirth);
            Contracts contracts = new Contracts();
            contracts.Country = customerDto.Country;
            contracts.Gender = customerDto.Gender;
            contracts.Dob = customerDto.DateOfBirth;
            contracts.SaleDate = customerDto.SaleDate;
            contracts.CustomerName = customerDto.Name;
            contracts.CustomerAddress = customerDto.Address;
            contracts.CoveragePlan = GetCoveragePlan(contracts.Country);

            if(IsContractStillValid(contracts.SaleDate, contracts.CoveragePlan))
            {
                contracts.RateChart = GetRateChartId(contracts.CoveragePlan, age, customerDto.Gender);

                _contractsRepository.Insert(contracts);
            }
            else
            {
                throw new Exception("This contract is not valid as this contract has expired.");
            }

        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age -= age;

            return age;
        }

        public void UpdateContract(Contracts contract)
        {
            if (contract != null)
            {
                var contractFromDb = _contractsRepository.Get(contract.Id);
                if (contractFromDb != null)
                {
                    contractFromDb.CustomerName = contract.CustomerName;
                    contractFromDb.CustomerAddress = contract.CustomerAddress;

                    bool isCountryChanged = contractFromDb.Country != contract.Country;
                    bool isGenderChanged = contractFromDb.Gender != contract.Gender;
                    bool isBirthDateChanged = contractFromDb.Dob != contract.Dob;
                    bool isSaleDateChanged = contractFromDb.SaleDate != contract.SaleDate;

                    if (isCountryChanged)
                    {
                        contractFromDb.Country = contract.Country;
                        contractFromDb.CoveragePlan = GetCoveragePlan(contractFromDb.Country);
                    }

                    if (isSaleDateChanged)
                    {
                        //Check if sale date is valid.
                        if(IsContractStillValid(contract.SaleDate, contractFromDb.CoveragePlan))
                        {
                            contractFromDb.SaleDate = contract.SaleDate;
                        }
                        else
                        {
                            throw new Exception("This contract is not valid as this contract has expired.");
                        }
                    }

                    if (isGenderChanged)
                    {
                        contractFromDb.Gender = contract.Gender;
                    }

                    if (isBirthDateChanged)
                    {
                        contractFromDb.Dob = contract.Dob;
                    }


                    var age = CalculateAge(contractFromDb.Dob);

                    contractFromDb.RateChart = GetRateChartId(contractFromDb.CoveragePlan, age, contractFromDb.Gender);

                    _contractsRepository.Update(contractFromDb);

                }
                else
                {
                    throw new Exception("This contraact does not exist. Please create a new one");
                }
            }
            else
            {
                throw new Exception("Please provide complete contract details");
            }
        }

        private bool IsContractStillValid(DateTime saleDate, int coveragePlan)
        {
            var plan = _coveragePlanRepository.Get(coveragePlan);
            if(plan != null)
            {
                if(saleDate >= plan.EligFromDate && saleDate <= plan.EligToDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception($"Coverage plan with id {coveragePlan} does not exist");
            }
        }

        public IEnumerable<ContractsView> GetContractsView()
        {
            return _contractsViewRepository.GetAll().ToList();
        }
    }
}
