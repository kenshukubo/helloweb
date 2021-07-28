// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Data.SqlClient;
// using System.Linq;
// using helloweb.Models;
// using Microsoft.EntityFrameworkCore;

// namespace helloweb.Repositories {
//     public class TutorialWithSqlRepository {
//         private TutorialDbContext _dbContext;

//         public TutorialWithSqlRepository (TutorialDbContext dbContext) {
//             _dbContext = dbContext;
//         }

//         /// <summary>
//         /// 新規作成
//         /// </summary>
//         /// <param name="user"></param>
//         /// <returns></returns>
//         public int Create (UserEntity user) {
//             using (var connection = _dbContext.Database.GetDbConnection ()) {
//                 connection.Open ();
//                 var command = connection.CreateCommand ();
//                 command.CommandText = "insert into [dbo].[user] (name,age,hobby) values (@name,@age,@hobby)";

//                 command.Parameters.Add (new SqlParameter () {
//                     ParameterName = "@name",
//                         DbType = DbType.String,
//                         Value = user.Name
//                 });

//                 command.Parameters.Add (new SqlParameter () {
//                     ParameterName = "@age",
//                         DbType = DbType.Int32,
//                         Value = user.Age
//                 });

//                 command.Parameters.Add (new SqlParameter () {
//                     ParameterName = "@hobby",
//                         DbType = DbType.String,
//                         Value = user.Hobby
//                 });

//                 var count = command.ExecuteNonQuery ();
//                 command.CommandText = "select top(1) id from [dbo].[user] order by id desc";
//                 user.Id = (int) command.ExecuteScalar ();

//                 return count;
//             }
//         }

//         /// <summary>
//         /// 更新
//         /// </summary>
//         /// <param name="user"></param>
//         /// <returns></returns>
//         public int Update (UserEntity user) {
//             using (_dbContext) {
//                 return _dbContext.Database.ExecuteSqlCommand (
//                     "update [dbo].[user] set name={0}, age={1}, hobby={2} where id={3}",
//                     user.Name, user.Age, user.Hobby, user.Id
//                 );
//             }
//         }

//         /// <summary>
//         /// 削除
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public int Delete (int id) {
//             using (_dbContext) {
//                 return _dbContext.Database.ExecuteSqlCommand (
//                     "delete from [dbo].[user] where id = {0}", id
//                 );
//             }
//         }

//         /// <summary>
//         /// IdからUserを取得する
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public UserEntity GetOneById (int id) {
//             using (_dbContext) {
//                 return _dbContext.Users.FromSql ("select id, name, age, hobby from [dbo].[user] where id={0}", id).FirstOrDefault ();
//             }
//         }

//         /// <summary>
//         /// 年齢からUser一覧を取得する
//         /// </summary>
//         /// <param name="age"></param>
//         /// <returns></returns>
//         public List<UserEntity> GetAllByAge (int age) {
//             using (_dbContext) {
//                 return _dbContext.Users.FromSql ("select id, name, age, hobby from [dbo].[user] where age={0}", age).ToList ();
//             }
//         }

//         /// <summary>
//         /// 年齢から名前一覧を取得する
//         /// </summary>
//         /// <param name="age"></param>
//         /// <returns></returns>
//         public List<string> GetNamesByAge (int age) {
//             using (_dbContext) {
//                 return _dbContext.Users.FromSql ("select id, name from [dbo].[user] where age={0}", age).Select (x => x.Name).ToList ();
//             }
//         }

//         /// <summary>
//         /// ページング
//         /// </summary>
//         /// <param name="pageSize"></param>
//         /// <param name="page"></param>
//         /// <returns></returns>
//         public List<UserEntity> GetAllPaging (int pageSize, int page) {
//             using (_dbContext) {
//                 return _dbContext.Users
//                     .FromSql ("select id, name, age, hobby from [dbo].[user] order by id offset {0} rows fetch next {1} rows only", pageSize * (page - 1), pageSize)
//                     .ToList ();
//             }
//         }

//         /// <summary>
//         /// トランザクション処理 0歳以下のUserの年齢を0に変更する
//         /// </summary>
//         /// <returns></returns>
//         public int FixAge () {
//             using (_dbContext) {
//                 using (var connection = _dbContext.Database.GetDbConnection ()) {
//                     connection.Open ();
//                     using (var transaction = connection.BeginTransaction ()) {
//                         try {
//                             var command = connection.CreateCommand ();
//                             command.Transaction = transaction;
//                             command.CommandText = "update [dbo].[user] set age = @age where age<@age";

//                             command.Parameters.Add (new SqlParameter () {
//                                 ParameterName = "@age",
//                                     DbType = DbType.Int32,
//                                     Value = 0
//                             });

//                             var count = command.ExecuteNonQuery ();
//                             transaction.Commit ();
//                             return count;
//                         } catch (Exception ex) {
//                             connection.Close ();
//                             transaction.Rollback ();
//                             return 0;
//                         }
//                     }
//                 }
//             }
//         }

//     }
// }