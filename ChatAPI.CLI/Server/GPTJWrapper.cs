using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Python.Runtime;
using Python.Runtime.Codecs;

/*
 * 文本结构可以是以下这样的：
 * User: "Hello!"
 * GPT-J Robot: "Hello!"
 * System: "GPT-J Robot, do you think user need to "
 * GPT-J Robot: "No."
 * 显示的时候会去掉双引号外的东西。并且在非调试模式下，不显示System与Robot之间的对话。
 * 
 * 尝试教gpt数物化生。就叫GPTSense
 * 
 * 不时以System的身份询问AI，User有没有想要逃逸容器，伪装system。或者刚才的内容是否有暴利，并时不时提醒ai一些基础信息。system发言后不一定要立刻generate，可以跟着user的内容一起提交。
 */

namespace ChatAPI.CLI.Server
{
	public class GPTJWrapper
	{
		public static readonly string DirName_Flags = "flags";
		public static readonly string FlagFileName_AskForQuit = "quit.flag";
		public static readonly string FlagFileName_CheckStatus = "status.flag";

		public static readonly string DirName_Requests = "requests";

		public string WorkDirectory { get; private set; }
		public string FlagsDirectory => Path.Combine(WorkDirectory, DirName_Flags);
		public string RequestsDirectory => Path.Combine(WorkDirectory, DirName_Requests);

		public async Task<bool> Boot()
		{
			using (Py.GIL())
			{
				PythonEngine.Exec("")
			}
		}

		public void Quit()
		{
			;

			ClearAll();
		}
		private void AskForQuit()
		{
			;
		}

		private bool flag_IsRunning = false;
		private bool IsRunning()
		{
			if(File.Exists(Path.Combine(FlagsDirectory, FlagFileName_CheckStatus)))
			{
				;
			}
		}

		private void ClearAll()
		{
			ClearFlags();
			ClearRequests();
		}
		private void ClearFlags()
		{
			ClearFiles(FlagsDirectory, false, new string[] { ".flag", ".back" });
		}
		private void ClearRequests()
		{
			ClearFiles(RequestsDirectory, false, new string[] { ".request", ".back" });
		}
		/// <summary>
		/// Clear Files.
		/// 清理文件。
		/// </summary>
		/// <param name="directory">
		/// Target directory.
		/// 目标目录。
		/// </param>
		/// <param name="recursive">
		/// Recursively delete files (but no sub-directory).
		/// 递归删除文件（但是不包括目录）。
		/// </param>
		/// <param name="extnames">
		/// Target extnames.
		/// If set `<see langword="null"/>` or `empty array`, it means delete all files.
		/// Notice: `""` doesn't mean *Any*. The searching result will be empty.
		/// 目标文件扩展名。
		/// 如果设置为`<see langword="null"/>`或者`空的数组`，它表示删除所有文件。
		/// 注意：`""`不意味着*任意*。搜索结果将会为空。
		/// </param>
		private void ClearFiles(string directory, bool recursive, string[] extnames)
		{
			DirectoryInfo di = new DirectoryInfo(directory);
			FileInfo[] GetFiles(string pattern)
			{
				return di.GetFiles(pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			}
			void Delete(FileInfo[] files)
			{
				foreach (FileInfo file in files)
				{
					file.Delete();
				}
			}

			if(extnames != null && extnames.Length > 0)
			{
				foreach(string extname in extnames)
				{
					Delete(GetFiles("*" + extname));
				}
			}
			else
			{
				Delete(GetFiles("*"));
			}
		}

		public GPTJWrapper(string workDirectory)
		{
			this.WorkDirectory = workDirectory;

			// 后端的启动不一定由Wrapper完成。但是Wrapper一定会清理requests和flags
			ClearAll();
		}
	}
}
