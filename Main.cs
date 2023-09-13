using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StudentsApiAzureFunction.DTO;
using StudentsApiAzureFunction.Model;
using StudentsApiAzureFunction.Service;

namespace StudentsApiAzureFunction
{
    public class Main
    {
        private readonly ILogger _logger;
        private readonly IStudentService _studentService;

        public Main(ILoggerFactory loggerFactory, IStudentService studentService)
        {
            _logger = loggerFactory.CreateLogger<Main>();
            _studentService = studentService;
        }

        [Function("getStudents")]
        [OpenApiOperation(operationId: "Students", tags: new[] { "Stundent" })]
        public async Task<HttpResponseData> GetStudents([Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Function, "get", Route = "students")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            _logger.LogInformation("Get students trigger fired");
            List<Student> students = _studentService.GetStudents();
            await response.WriteAsJsonAsync(students);
            return response;
        }

        [Function("GetStudentById")]
        [OpenApiOperation(operationId: "Students", tags: new[] { "Stundent" })]
        public async Task<HttpResponseData> GetStudentById([Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Function, "get", Route = "students/{id:int}")] HttpRequestData req, int id)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            _logger.LogInformation("Get student by id trigger fired");
            Student student = _studentService.GetStudent(id);
            await response.WriteAsJsonAsync(student);
            return response;
        }

        [Function("CreateStudent")]
        [OpenApiOperation(operationId: "Students", tags: new[] { "Stundent" })]
        public async Task<HttpResponseData> CreateStudent([Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Function, "post", Route = "students")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            _logger.LogInformation("Create student trigger fired");
            var studentDto = await req.ReadFromJsonAsync<StudentCreateDto>();
            Student student = _studentService.CreateStudent(studentDto);
            await response.WriteAsJsonAsync(student);
            return response;
        }

        [Function("DeleteStudent")]
        [OpenApiOperation(operationId: "Students", tags: new[] { "Stundent" })]
        public async Task<HttpResponseData> DeleteStudent([Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Function, "delete", Route = "students/{id:int}")] HttpRequestData req, int id)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            _studentService.DeleteStudent(id);
            return response;
        }

        [Function("UpdateStudent")]
        [OpenApiOperation(operationId: "Students", tags: new[] { "Stundent" })]
        public async Task<HttpResponseData> UpdateStudent([Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Function, "put", Route = "students/{id:int}")] HttpRequestData req, int id)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            _logger.LogInformation("Update student by id trigger fired");
            var studentDto = await req.ReadFromJsonAsync<UpdateStudentDto>();
            _studentService.UpdateStudent(studentDto);
            return response;
        }


    }
}
