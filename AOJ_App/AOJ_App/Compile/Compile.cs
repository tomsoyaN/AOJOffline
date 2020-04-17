using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOJ_App.Compile
{
    class debugger//コンパイラ部のファイル@tom
    {
        public debugger()//コンストラクタ@tom
        {

        }

        public void Execute(string text)//コンパイラ本体?@tom
        {
            //エディタの文をcppファイルとして保存
            //文字コードの指定
            Encoding enc = Encoding.GetEncoding("utf-8");
            //保存場所の指定,0000はファイル名
            StreamWriter writer = new StreamWriter(@"C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\0000.cpp", false, enc);
            writer.Write(text);
            writer.Close();


            //コンパイラ起動
            //二つ目の引数はコンパイルしたいcppファイルの保存場所およびファイル名
            //a.exeはAOJOffline\AOJ_App\AOJ_App\bin\Debugに保存される模様
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("g++", @"C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\0000.cpp");
            p.WaitForExit(10000);

            //生成された実行ファイルを実行
            //二つ目の引数は実行したいexeファイルの保存場所およびファイル名
            System.Diagnostics.Process.Start("a.exe", @"C:\C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\a.exe");
        }
    }
}
