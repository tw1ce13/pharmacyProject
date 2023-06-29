using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly IBaseRepository<Patient> _patientRepository;
    public PatientService(IBaseRepository<Patient> patientRepository)
    {
        _patientRepository = patientRepository;
    }


    public async Task<IBaseResponse<Patient>> Add(Patient patient)
    {
        await _patientRepository.Add(patient);
        var baseResponse = new BaseResponse<Patient>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = patient
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Patient>> Delete(int id, CancellationToken token)
    {
        var patient = await _patientRepository.GetById(id, token);
        await _patientRepository.Delete(patient);
        var baseResponse = new BaseResponse<Patient>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = patient
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Patient>> Delete(Patient patient)
    {
        await _patientRepository.Delete(patient);
        var baseResponse = new BaseResponse<Patient>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = patient
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Patient>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Patient>();
        var patient = await _patientRepository.GetById(id, token);
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


    public async Task<IBaseResponse<IEnumerable<Patient>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Patient>>();
        var patients = await _patientRepository.GetAll();
        if (patients == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = patients;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Patient>> Update(Patient patient)
    {
        var baseResponse = new BaseResponse<Patient>();
        if (patient == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }

        await _patientRepository.Update(patient);

        baseResponse.Data = patient;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

