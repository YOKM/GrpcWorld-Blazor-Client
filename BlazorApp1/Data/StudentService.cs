using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcService.Protos;


namespace BlazorApp1.Data
{


    public class StudentService
    {
        GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
       

        public async Task<string> GetStudentByID(int id)
        {

            var studentClient = new RemoteStudent.RemoteStudentClient(channel);
           
            var studentInput = new StudentLookupModel { StudentId = id };
            var studentReply = await studentClient.GetStudentInfoAsync(studentInput);
           
            //  Console.WriteLine($"{studentReply.FirstName} { studentReply.LastName}");

            // var name = 

            return studentReply.LastName + " " + studentReply.FirstName;


            //AppContext.SetSwitch(
            //   "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
            //   true);

            //var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://localhost:50051");

            //var client =  Grpc.Net.Client.GrpcChannel    GrpcClient.Create<grpcGreeter.Greeter.GreeterClient>(httpClient);
            //grpcGreeter.HelloReply reply = await client.SayHelloAsync(new grpcGreeter.HelloRequest() { Name = name });
            //return reply.Message;
        }


        public async Task<string> AddNewStd(StudentModel aNewStudent)
        {
            
            var client = new RemoteStudent.RemoteStudentClient(channel);

            var reply = await client.InsertStudentAsync(aNewStudent);

            return reply.ToString();

        }


     

    }


}
