using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTest
{
    /// <summary>
    /// テンプレートとなるクラス
    /// DoProcessをテンプレートとして継承先で中身のクラスを実装
    /// </summary>
    abstract class AbstractTemplateProcess
    {
        protected string ProcessName;
        protected string Tran;
        protected string[] InputFiles;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tran"></param>
        public AbstractTemplateProcess(String tran)
        {
            this.Tran = tran;
        }

        /// <summary>
        /// メイン処理
        /// 各インプットファイル取込み処理のテンプレート
        /// </summary>
        public void DoProcess()
        {
            Console.WriteLine(this.ProcessName + "開始");

            InputFiles = GetInputFiles();

            //インプットファイル件数チェック
            if (InputFiles.Length == 0)
            {
                Console.WriteLine("ファイルがありません。");
                return;
            }

            //ファイル数分繰返し
            for (int i = 0; i < InputFiles.Length; i++)
            {
                string afile = InputFiles[i];
                //ファイル毎にトランザクション管理
                Tran = "Begin";
                try
                {
                    //ファイル中身取得
                    List<string> rows = Util.GetContents(afile);
                    //行数分繰り返し
                    foreach (string oneRow in rows)
                    {
                        string[] inputColumns = oneRow.Split(',');
                        //エラーチェック
                        CheckError(inputColumns);

                        //各処理個別の変換処理
                        string[] outputColumns = EditInputToOutput(inputColumns);

                        //DBインサート
                        InsertRecord(outputColumns);
                    }

                    //インプットファイル削除
                    System.IO.File.Delete(afile);

                }
                catch (Exception ex)
                {
                    Tran = "RollBack";
                    throw new Exception(ex.Message);
                }

                //ファイル毎にコミット
                Tran="commit";
                Console.WriteLine(this.ProcessName + "終了");
            }
        }

        /// <summary>
        /// インプットファイル取得処理
        /// 継承先で実装
        /// </summary>
        /// <returns>インプットファイル名の配列</returns>
        protected virtual string[] GetInputFiles();

        /// <summary>
        /// エラーチェック処理
        /// 継承先で実装
        /// </summary>
        protected virtual void CheckError(String[] columns);

        /// <summary>
        /// カラム変換処理
        /// 継承先で実装
        /// </summary>
        /// <param name="columns">インプットカラム列</param>
        /// <returns></returns>
        protected virtual string[] EditInputToOutput(string[] columns);

        /// <summary>
        /// DBインサート
        /// 継承先で実装
        /// </summary>
        protected virtual void InsertRecord(string[] columns);
        
    }

    /// <summary>
    /// ヘッダー処理クラス
    /// </summary>
    public class HeaderProcess : AbstractTemplateProcess
    {
        public HeaderProcess(String trn)
            : base(trn)
        {
            this.ProcessName = "ヘッダー処理"; 
        }

        protected override string[] GetInputFiles()
        {
            string[] files = { "test.txt", "hoge.txt", "hage.txt" };
            return files;
        }

        protected override void CheckError(String[] columns)
        {
            if (columns[0] == null)
            {
                throw new Exception();
            }
        }

        protected override string[] EditInputToOutput(string[] columns)
        {
            string acolumn = columns[0] + "_suffix";
            string bcolumn = "prefix_" + columns[1];
            return new string[]{acolumn,bcolumn};
        }

        protected override void InsertRecord(string[] columns)
        {
            //insert処理を実装
        }
    }

    /// <summary>
    /// 詳細処理クラス
    /// </summary>
    public class DetailProcess : AbstractTemplateProcess
    {
        public DetailProcess(String trn)
            : base(trn)
        {
            this.ProcessName = "詳細処理"; 
        }

        protected override string[] GetInputFiles()
        {
            string[] files = { "hige.txt", "HelloWorld.txt" };
            return files;
        }

        protected override void CheckError(String[] columns)
        {
            if ((columns[1] == null) && (columns[2] == null))
            {
                throw new Exception();
            }
        }

        protected override string[] EditInputToOutput(string[] columns)
        {
            string acolumn = "prefix" + columns[0];
            string bcolumn =  columns[1] + "_suffix";
            return new string[] { acolumn, bcolumn };
        }

        protected override void InsertRecord(string[] columns)
        {
            //insert処理を実装
        }
    }

}
