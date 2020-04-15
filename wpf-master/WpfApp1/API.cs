using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static class Program
    {
        static async Task Login_Program(String user,String password)
        {
            
            var obj = new API();
            var result = await obj.LoginAsync(user, password);
            if (result == "[{\"id\":1401,\"code\":\"USER_NOT_FOUND_ERROR\",\"message\":\"The user identified by  and the password is not found.\"}]")
            {
                Console.WriteLine("Wrong the ID or Password!!");
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
        static async Task Main()
        {
            Console.Write("username >>>");
            var user = Console.ReadLine();

            Console.Write("password >>>");
            var password = Console.ReadLine();

            var obj = new API();
            var result = await obj.LoginAsync(user, password);
            if (result == "[{\"id\":1401,\"code\":\"USER_NOT_FOUND_ERROR\",\"message\":\"The user identified by  and the password is not found.\"}]")
            {
                Console.WriteLine("Wrong the ID or Password!!");
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine();
            }


            var self = await obj.SelfAsync();
            Console.WriteLine(self);
            var submission = await obj.SubmissionAsync("ITP1_1_A", "Python", "print('Hello World')");
            Console.WriteLine(submission);
            var Judge = await obj.JudgeAsync((4252705));
            Console.WriteLine(Judge);
            Console.ReadKey();
        }
    }

    public class API
    {
        //プログラム作成参考( https://teratail.com/questions/251616)
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler())//{ UseCookies = true, })
        {
            BaseAddress = new Uri("https://judgeapi.u-aizu.ac.jp/"),
        };

        public async Task<string> LoginAsync(string id, string pass)
        {
            var json = $@"{{""id"":""{id}"",""password"":""{pass}""}}";
            Debug.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("session", content);
            Debug.WriteLine($"content ->> {content}");

            if (response.Headers.Contains("Set-Cookie"))
            {
                var cookie = response.Headers.GetValues("Set-Cookie").First();
                Console.WriteLine($"cookie --> {cookie}\n");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SubmissionAsync(string problem_id, string language, string code)
        {
            var json = $@"{{""problemId"":""{problem_id}"",""language"":""{language}"",""sourceCode"":""{code}""}}";
            //var json = "{\"problemId\":\"ITP1_1_A\",\"language\":\"C++\",\"sourceCode\":\"#include <iostream>\\nusing namespace std;\\nint main(void){\\n    cout << \"Hello World\" << endl;\\n}\"}";
            Console.WriteLine(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("submissions", content);
            Debug.WriteLine($"content ->> {content}");

            return await response.Content.ReadAsStringAsync();
        }


        public Task<string> SelfAsync() => GetAsync("self");
        public Task<string> JudgeAsync(int judge_id) => GetAsync("/verdicts/4252705");
        public async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();

        }
    }
}