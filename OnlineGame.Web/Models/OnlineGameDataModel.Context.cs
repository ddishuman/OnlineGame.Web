﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineGame.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OnlineGameEntities : DbContext
    {
        public OnlineGameEntities()
            : base("name=OnlineGameEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Gamer> Gamers { get; set; }
        public virtual DbSet<GamerDetail> GamerDetails { get; set; }
        public virtual DbSet<GamerMagic> GamerMagics { get; set; }
        public virtual DbSet<GamerSkill> GamerSkills { get; set; }
        public virtual DbSet<Magic> Magics { get; set; }
        public virtual DbSet<MultipleSelect> MultipleSelects { get; set; }
        public virtual DbSet<SingleSelect> SingleSelects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<ContactComment> ContactComments { get; set; }
    
        public virtual int spAddGamer(string name, string gender, string city, Nullable<System.DateTime> dateOfBirth, string emailAddress, Nullable<int> score, string profileUrl, string rolePhoto, string rolePhotoAltText, Nullable<int> gameMoney, Nullable<int> teamId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(int));
    
            var profileUrlParameter = profileUrl != null ?
                new ObjectParameter("ProfileUrl", profileUrl) :
                new ObjectParameter("ProfileUrl", typeof(string));
    
            var rolePhotoParameter = rolePhoto != null ?
                new ObjectParameter("RolePhoto", rolePhoto) :
                new ObjectParameter("RolePhoto", typeof(string));
    
            var rolePhotoAltTextParameter = rolePhotoAltText != null ?
                new ObjectParameter("RolePhotoAltText", rolePhotoAltText) :
                new ObjectParameter("RolePhotoAltText", typeof(string));
    
            var gameMoneyParameter = gameMoney.HasValue ?
                new ObjectParameter("GameMoney", gameMoney) :
                new ObjectParameter("GameMoney", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddGamer", nameParameter, genderParameter, cityParameter, dateOfBirthParameter, emailAddressParameter, scoreParameter, profileUrlParameter, rolePhotoParameter, rolePhotoAltTextParameter, gameMoneyParameter, teamIdParameter);
        }
    
        public virtual int spDeleteGamer(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteGamer", idParameter);
        }
    
        public virtual int spDeleteGamerAndDetail(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteGamerAndDetail", idParameter);
        }
    
        public virtual int spDeleteGamerMagic(Nullable<int> gamerId, Nullable<int> magicId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            var magicIdParameter = magicId.HasValue ?
                new ObjectParameter("MagicId", magicId) :
                new ObjectParameter("MagicId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteGamerMagic", gamerIdParameter, magicIdParameter);
        }
    
        public virtual int spDeleteGamerSkill(Nullable<int> gamerId, Nullable<int> skillId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            var skillIdParameter = skillId.HasValue ?
                new ObjectParameter("SkillId", skillId) :
                new ObjectParameter("SkillId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteGamerSkill", gamerIdParameter, skillIdParameter);
        }
    
        public virtual int spGetAllFromDynamicTableName(string schemaName, string tableName)
        {
            var schemaNameParameter = schemaName != null ?
                new ObjectParameter("SchemaName", schemaName) :
                new ObjectParameter("SchemaName", typeof(string));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spGetAllFromDynamicTableName", schemaNameParameter, tableNameParameter);
        }
    
        public virtual ObjectResult<spGetGamers_Result> spGetGamers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetGamers_Result>("spGetGamers");
        }
    
        public virtual int spInsertGamerAndDetail(string name, string gender, string email, Nullable<System.DateTime> birthday, Nullable<int> teamId, Nullable<int> areaId, Nullable<int> experience, Nullable<int> level, Nullable<decimal> gameMoney)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("Birthday", birthday) :
                new ObjectParameter("Birthday", typeof(System.DateTime));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var areaIdParameter = areaId.HasValue ?
                new ObjectParameter("AreaId", areaId) :
                new ObjectParameter("AreaId", typeof(int));
    
            var experienceParameter = experience.HasValue ?
                new ObjectParameter("Experience", experience) :
                new ObjectParameter("Experience", typeof(int));
    
            var levelParameter = level.HasValue ?
                new ObjectParameter("Level", level) :
                new ObjectParameter("Level", typeof(int));
    
            var gameMoneyParameter = gameMoney.HasValue ?
                new ObjectParameter("GameMoney", gameMoney) :
                new ObjectParameter("GameMoney", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertGamerAndDetail", nameParameter, genderParameter, emailParameter, birthdayParameter, teamIdParameter, areaIdParameter, experienceParameter, levelParameter, gameMoneyParameter);
        }
    
        public virtual int spInsertGamerMagic(Nullable<int> gamerId, Nullable<int> magicId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            var magicIdParameter = magicId.HasValue ?
                new ObjectParameter("MagicId", magicId) :
                new ObjectParameter("MagicId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertGamerMagic", gamerIdParameter, magicIdParameter);
        }
    
        public virtual int spInsertGamerSkill(Nullable<int> gamerId, Nullable<int> skillId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            var skillIdParameter = skillId.HasValue ?
                new ObjectParameter("SkillId", skillId) :
                new ObjectParameter("SkillId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertGamerSkill", gamerIdParameter, skillIdParameter);
        }
    
        public virtual int spMagicAssignToTheGamer(Nullable<int> gamerId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMagicAssignToTheGamer", gamerIdParameter);
        }
    
        public virtual ObjectResult<spMagicNotAssignToTheGamer_Result> spMagicNotAssignToTheGamer(Nullable<int> gamerId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMagicNotAssignToTheGamer_Result>("spMagicNotAssignToTheGamer", gamerIdParameter);
        }
    
        public virtual int spOutputGamerCountByGender(string gender, ObjectParameter gamerCount)
        {
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spOutputGamerCountByGender", genderParameter, gamerCount);
        }
    
        public virtual int spSaveGamer(Nullable<int> id, string name, string gender, string city, Nullable<System.DateTime> dateOfBirth, string emailAddress, Nullable<int> score, string profileUrl, Nullable<int> gameMoney, Nullable<int> teamId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(int));
    
            var profileUrlParameter = profileUrl != null ?
                new ObjectParameter("ProfileUrl", profileUrl) :
                new ObjectParameter("ProfileUrl", typeof(string));
    
            var gameMoneyParameter = gameMoney.HasValue ?
                new ObjectParameter("GameMoney", gameMoney) :
                new ObjectParameter("GameMoney", typeof(int));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSaveGamer", idParameter, nameParameter, genderParameter, cityParameter, dateOfBirthParameter, emailAddressParameter, scoreParameter, profileUrlParameter, gameMoneyParameter, teamIdParameter);
        }
    
        public virtual int spSearchGamerAndDetail(Nullable<int> id, string name, string email, string gender, Nullable<int> teamId, Nullable<int> areaId, Nullable<int> experienceGreaterThanOrEqual, Nullable<int> levelGreaterThanOrEqual, Nullable<decimal> gameMoneyGreaterThan)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var areaIdParameter = areaId.HasValue ?
                new ObjectParameter("AreaId", areaId) :
                new ObjectParameter("AreaId", typeof(int));
    
            var experienceGreaterThanOrEqualParameter = experienceGreaterThanOrEqual.HasValue ?
                new ObjectParameter("ExperienceGreaterThanOrEqual", experienceGreaterThanOrEqual) :
                new ObjectParameter("ExperienceGreaterThanOrEqual", typeof(int));
    
            var levelGreaterThanOrEqualParameter = levelGreaterThanOrEqual.HasValue ?
                new ObjectParameter("LevelGreaterThanOrEqual", levelGreaterThanOrEqual) :
                new ObjectParameter("LevelGreaterThanOrEqual", typeof(int));
    
            var gameMoneyGreaterThanParameter = gameMoneyGreaterThan.HasValue ?
                new ObjectParameter("GameMoneyGreaterThan", gameMoneyGreaterThan) :
                new ObjectParameter("GameMoneyGreaterThan", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSearchGamerAndDetail", idParameter, nameParameter, emailParameter, genderParameter, teamIdParameter, areaIdParameter, experienceGreaterThanOrEqualParameter, levelGreaterThanOrEqualParameter, gameMoneyGreaterThanParameter);
        }
    
        public virtual int spSelectGamerMagic()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSelectGamerMagic");
        }
    
        public virtual ObjectResult<spSelectGamers_Result> spSelectGamers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSelectGamers_Result>("spSelectGamers");
        }
    
        public virtual ObjectResult<spSelectGamersAndTeams_Result> spSelectGamersAndTeams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSelectGamersAndTeams_Result>("spSelectGamersAndTeams");
        }
    
        public virtual int spSelectGamerSkill()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSelectGamerSkill");
        }
    
        public virtual int spSkillsAssignToTheGamer(Nullable<int> gamerId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSkillsAssignToTheGamer", gamerIdParameter);
        }
    
        public virtual ObjectResult<spSkillsNotAssignToTheGamer_Result> spSkillsNotAssignToTheGamer(Nullable<int> gamerId)
        {
            var gamerIdParameter = gamerId.HasValue ?
                new ObjectParameter("GamerId", gamerId) :
                new ObjectParameter("GamerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSkillsNotAssignToTheGamer_Result>("spSkillsNotAssignToTheGamer", gamerIdParameter);
        }
    
        public virtual int spUpdateGamerAndDetail(Nullable<int> id, string name, string gender, string email, Nullable<System.DateTime> birthday, Nullable<int> teamId, Nullable<int> areaId, Nullable<int> experience, Nullable<int> level, Nullable<decimal> gameMoney)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("Birthday", birthday) :
                new ObjectParameter("Birthday", typeof(System.DateTime));
    
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(int));
    
            var areaIdParameter = areaId.HasValue ?
                new ObjectParameter("AreaId", areaId) :
                new ObjectParameter("AreaId", typeof(int));
    
            var experienceParameter = experience.HasValue ?
                new ObjectParameter("Experience", experience) :
                new ObjectParameter("Experience", typeof(int));
    
            var levelParameter = level.HasValue ?
                new ObjectParameter("Level", level) :
                new ObjectParameter("Level", typeof(int));
    
            var gameMoneyParameter = gameMoney.HasValue ?
                new ObjectParameter("GameMoney", gameMoney) :
                new ObjectParameter("GameMoney", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateGamerAndDetail", idParameter, nameParameter, genderParameter, emailParameter, birthdayParameter, teamIdParameter, areaIdParameter, experienceParameter, levelParameter, gameMoneyParameter);
        }

        public System.Data.Entity.DbSet<OnlineGame.Web.Models.GamerA> GamerAs { get; set; }
    }
}
