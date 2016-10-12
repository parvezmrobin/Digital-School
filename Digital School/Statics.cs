using Digital_School.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Digital_School
{
	public static class Statics
	{
		public static string Error { get { return "~/Error.html"; } }
		public static string Error404 { get { return "~/404.html"; } }
		public static string ResponseFolder { get { return "~/Response/"; } }
		public static string Admin { get { return "Administrator"; } }
		public static string AdminPassword { get { return "pa$$word"; } }
		public static string Teacher { get { return "Teacher"; } }
		public static string Student { get { return "Student"; } }
		//public static string ConnectionString {
		//	get { return "server=localhost;user=root;database=" + DatabaseName + ";port=3306;"; }
		//}

		//public static string DatabaseName { get; set; } = "sdp";
		public static string SchoolEmailId { get { return "dscseku@gmail.com"; } internal set { SchoolEmailId = value; } }
		public static string SchoolEmailPassword { get { return "Digital School"; } internal set { SchoolEmailPassword = value; } }

		#region Settings Varialbles
		private static Dictionary<string, bool> settings = new Dictionary<string, bool>() {
			{"Notification On Transaction", true },
			{"Notification On Answer", true },
			{"Notification On Question", true },
			{"Notification On Event", true },
			{"Responses Will Be Removed After Creating Result", true }
		};
		public static Dictionary<string, bool> Settings {
			get { return settings; }
		}

		public static string NotificationOnTransaction { get { return "Notification On Transaction"; } }
		public static string NotificationOnAnswer { get { return "Notification On Answer"; } }
		public static string NotificationOnQuestion { get { return "Notification On Question"; } }
		public static string NotificationOnEvent { get { return "Notification On Event"; } }
		public static string ResponsesShouldBeRemoved { get { return "Responses Will Be Removed After Creating Result"; } }

		#endregion

		//public static DataSet getDataSetByProc(string procName, params MySqlParameter[] parameters) {

		//	using (MySqlConnection conn = new MySqlConnection(ConnectionString)) {
		//		MySqlDataAdapter da = new MySqlDataAdapter(procName, conn);
		//		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		//		foreach (var param in parameters)
		//			da.SelectCommand.Parameters.Add(param);
		//		DataSet ds = new DataSet();
		//		da.Fill(ds);
		//		return ds;

		//		s
		//	}
		//}

		//public static Post getPostById(int? PostId) {
		//	Post post = null;
		//	using (MySqlConnection conn = new MySqlConnection(ConnectionString)) {
		//		MySqlCommand cmnd = new MySqlCommand("getPostById", conn);
		//		cmnd.Parameters.AddWithValue("@pid", PostId);
		//		cmnd.CommandType = CommandType.StoredProcedure;
		//		conn.Open();
		//		MySqlDataReader reader = cmnd.ExecuteReader();
		//		if (reader.Read()) {
		//			post = new Post();
		//			post.Title = reader[0].ToString();
		//			//post.de = reader[1].ToString();
		//		}
		//	}
		//	return post;
		//}

		//public static long? insertInto(string procName, params MySqlParameter[] param) {
		//	long? ret = null;
		//	using (MySqlConnection conn = new MySqlConnection(ConnectionString)) {
		//		MySqlCommand cmd = new MySqlCommand(procName, conn);
		//		cmd.CommandType = CommandType.StoredProcedure;
		//		foreach (var p in param)
		//			cmd.Parameters.Add(p);

		//		conn.Open();
		//		cmd.ExecuteNonQuery();
		//		cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", conn);
		//		ret = Convert.ToInt64(cmd.ExecuteScalar());
		//	}
		//	return ret;
		//}

		//public static string getLastSummaryByType(int type) {
		//	string ret = null;
		//	using (MySqlConnection conn = new MySqlConnection(ConnectionString)) {
		//		MySqlCommand cmd = new MySqlCommand("getLastSummaryByType", conn);
		//		cmd.CommandType = CommandType.StoredProcedure;
		//		cmd.Parameters.AddWithValue("@ptype", type);
		//		conn.Open();
		//		MySqlDataReader reader = cmd.ExecuteReader();
		//		if (reader.Read())
		//			ret = reader[0].ToString();
		//	}
		//	return ret;
		//}


	}

}