using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Identity.MySQL
{
	/// <summary>
	/// Class that implements the key ASP.NET Identity role store iterfaces
	/// </summary>
	public class RoleStore<TRole> : IQueryableRoleStore<TRole>
		where TRole : IdentityRole
	{
		private RoleTable roleTable;
		/// <summary>
		/// Get the underlying database
		/// </summary>
		public MySQLDatabase Database { get; private set; }
		/// <summary>
		/// Get Queryable Roles
		/// </summary>
		
		public IQueryable<TRole> Roles {
			get {
				string connstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				MySqlConnection conn = new MySqlConnection(connstr);
				string query = "SELECT * FROM roles";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				conn.Open();
				MySqlDataReader reader = cmd.ExecuteReader();
				List<TRole> roles = new List<TRole>();
				while (reader.Read()) {
					TRole role = (TRole)Activator.CreateInstance(typeof(TRole));
					role.Id = reader["Id"].ToString();
					role.Name = reader["Name"].ToString();
					roles.Add(role);
				}
				conn.Close();
				return roles.AsQueryable();
			}
		}


		/// <summary>
		/// Default constructor that initializes a new MySQLDatabase
		/// instance using the Default Connection string
		/// </summary>
		public RoleStore() {
			new RoleStore<TRole>(new MySQLDatabase());
		}

		/// <summary>
		/// Constructor that takes a MySQLDatabase as argument 
		/// </summary>
		/// <param name="database"></param>
		public RoleStore(MySQLDatabase database) {
			Database = database;
			roleTable = new RoleTable(database);
		}

		public Task CreateAsync(TRole role) {
			if (role == null) {
				throw new ArgumentNullException("role");
			}

			roleTable.Insert(role);

			return Task.FromResult<object>(null);
		}

		public Task DeleteAsync(TRole role) {
			if (role == null) {
				throw new ArgumentNullException("user");
			}

			roleTable.Delete(role.Id);

			return Task.FromResult<Object>(null);
		}

		public Task<TRole> FindByIdAsync(string roleId) {
			TRole result = roleTable.GetRoleById(roleId) as TRole;

			return Task.FromResult<TRole>(result);
		}

		public Task<TRole> FindByNameAsync(string roleName) {
			TRole result = roleTable.GetRoleByName(roleName) as TRole;

			return Task.FromResult<TRole>(result);
		}

		public Task UpdateAsync(TRole role) {
			if (role == null) {
				throw new ArgumentNullException("user");
			}

			roleTable.Update(role);

			return Task.FromResult<Object>(null);
		}

		public void Dispose() {
			if (Database != null) {
				Database.Dispose();
				Database = null;
			}
		}

	}
}
