using System.Runtime.Serialization;

namespace Application.Services.People
{
    public class PersonDto
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        [IgnoreDataMember]
        public int Age
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling(DateTime.Now.Subtract(BirthDate).TotalDays / 365));
            }
        }
    }
}
