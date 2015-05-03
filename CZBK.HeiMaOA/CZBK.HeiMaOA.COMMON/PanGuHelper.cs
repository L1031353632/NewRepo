using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using PanGu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.COMMON
{
    public class PanGuHelper
    {
        /// <summary>
        /// 对索引分词
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] SqlitIndexWord(string str)
        {
            //盘古分词 //对输入的搜索条件进行分词
            List<string> list = new List<string>();
            Analyzer analyzer = new PanGuAnalyzer();
            TokenStream tokenStream = analyzer.TokenStream("", new StringReader(str));
            Lucene.Net.Analysis.Token token = null;
            while ((token = tokenStream.Next()) != null)
            {
                Console.WriteLine(token.TermText());
                list.Add(token.TermText());
            }

            return list.ToArray();
        }


        /// <summary>
        /// 创建HTMLFormatter,参数为高亮单词的前后缀
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static string CreateHightLight(string keywords, string Content)
        {
            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter =
             new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
            //创建Highlighter ，输入HTMLFormatter 和盘古分词对象Semgent
            PanGu.HighLight.Highlighter highlighter =
            new PanGu.HighLight.Highlighter(simpleHTMLFormatter,
            new Segment());
            //设置每个摘要段的字符数
            highlighter.FragmentSize = 150;
            //获取最匹配的摘要段
            return highlighter.GetBestFragment(keywords, Content);

        }
    }
}
