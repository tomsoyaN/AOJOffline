using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace AOJ_App.Network
{
    class API//HTTP通信オブジェクト定義クラス
    {
        //プログラム作成参考( https://teratail.com/questions/251616)
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler())//{ UseCookies = true, })
        {
            BaseAddress = new Uri("https://judgeapi.u-aizu.ac.jp"),
            //BaseAddress = new Uri("https://judgedat.u-aizu.ac.jp/"), //testcase用
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



        public Task<string> GetproblemAsync(string URI) => GetAsync(URI);
        public async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();

        }
    }
}

