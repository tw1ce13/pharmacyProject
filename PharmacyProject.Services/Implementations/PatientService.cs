using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IBaseRepository<Patient> _patientRepository;



        public PatientService(IBaseRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }



        public IBaseResponse<Patient> Add(Patient patient)
        {
            _patientRepository.Add(patient);
            var baseResponse = new BaseResponse<Patient>("Success", StatusCode.OK, patient);
            return baseResponse;
        }



        public IBaseResponse<Patient> Delete(int id)
        {
            Patient patient = new Patient() { Id = id };
            _patientRepository.Delete(patient);
            var baseResponse = new BaseResponse<Patient>("Success", StatusCode.OK, patient);
            return baseResponse;
        }

        public IBaseResponse<Patient> Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
            var baseResponse = new BaseResponse<Patient>("Success", StatusCode.OK, patient);
            return baseResponse;
        }

        public async Task<IBaseResponse<Patient>> Get(int id)
        {
            var baseResponse = new BaseResponse<Patient>();
            try
            {
                var patient = await _patientRepository.GetById(id);
                if (patient == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = patient;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Patient>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Patient>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Patient>>();
            try
            {
                var patient = await _patientRepository.GetAll();
                if (patient == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = patient;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Patient>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Patient> Update(Patient obj)
        {
            var baseResponse = new BaseResponse<Patient>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                _patientRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Patient>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

