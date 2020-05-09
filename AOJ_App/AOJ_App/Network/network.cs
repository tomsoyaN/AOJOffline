using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOJ_App.Network
{
    class network//AOJとの通信専用クラス@tom
    {
        public API obj;//通信オブジェクト用フィールド@tom
        static public network net;
        public network()//コンストラクタ@tom
        {
            obj = new API();
        }
        public async Task<bool> Login(string user, string password)//ログインメソッド@tom
        {

            string result = await obj.LoginAsync(user, password);
            string[] result1 = result.Split(',');
            string wrongpass = "[{\"id\":1401"; //返答文字列を分割することでログインエラーを認知する@kurikinton
            if (result1[0] == wrongpass)
            {
                Console.WriteLine("Wrong the ID or Password!!"); //パスワードのエラー
                return false;
            }
            else
            {
                Console.WriteLine("パスワードが正しく処理されました");
                return true;
            }
            /***
            //問題取得用
            string[] ABC = new string[4] { "A", "B", "C", "D" };
            for (int i = 1; i <= 11; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string problemID = "ITP1_" + i + "_" + ABC[j];
                    // 文字コードを指定
                    Encoding enc = Encoding.GetEncoding("UTF-16");
                    for (int k = 0; k < 20; k++)
                    {
                        var IDA = k + 1;
                        string code = "testcases/" + problemID + "/" + IDA;
                        //Console.WriteLine(code);
                        var problem = await obj.GetproblemAsync(code);
                        //Console.WriteLine(problem);

                        // ファイルを開く
                        StreamWriter writer = new StreamWriter(problemID + "_" + IDA + ".json", false, enc);
                        // テキストを書き込む
                        writer.WriteLine(problem);
                        Console.WriteLine(problemID + "/" + IDA);
                        // ファイルを閉じる
                        writer.Close();  
                    }    
                }
                
            }
            ***/
        }

        public async Task<int> Submmission()//サブミッションメソッド@tom
        {
            var self = await obj.SelfAsync();
            Console.WriteLine(self);
            var submission = await obj.SubmissionAsync("ITP1_1_A", "Python", "print('Hello World')");
            Console.WriteLine(submission);
            var Judge = await obj.JudgeAsync((4252705));
            Console.WriteLine(Judge);
            return 1;
        }
    }
}

