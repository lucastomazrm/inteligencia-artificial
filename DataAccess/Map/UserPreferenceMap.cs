// using IA.inteligencia_artificial.Models;
// using Microsoft.EntityFrameworkCore;

// namespace IA.inteligencia_artificial.DataAccess
// {
//     public partial class MainContext : DbContext
//     {
//         public static void UserPreferenceMap(ModelBuilder modelBuilder)
//         {
//             var map = modelBuilder.Entity<UserPreference>().ToTable("USER_PREFERENCE");
//             // Primary Key
//             map.HasKey(t => t.Id);

//             // Table & Column Mappings
//             map.Property(t => t.Id).HasColumnName("ID");
//             map.Property(t => t.UserPreferenceTypeId).HasColumnName("USER_PREFERENCE_TYPE_ID");
//             map.Property(t => t.UserName).HasColumnName("USER_NAME");
//             map.Property(t => t.Value).HasColumnName("VALUE");

//             map.HasOne(x => x.UserPreferenceType)
//                .WithMany(x => x.UserPreferences)
//                .HasForeignKey(x => x.UserPreferenceTypeId);
//         }
//     }
// }
