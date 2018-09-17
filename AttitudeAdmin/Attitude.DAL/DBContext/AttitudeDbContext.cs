using System.Data.Entity;
using AttitudeAdmin.DBContext.Entities;
using AttitudeMeasurement.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AttitudeAdmin.DBContext
{
    public class AttitudeDbContext : IdentityDbContext<ApplicationUser>
    {
        public AttitudeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static AttitudeDbContext Create()
        {
            return new AttitudeDbContext();
        }
    }
}