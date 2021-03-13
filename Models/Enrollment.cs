namespace ContosoUniversity.Models
{
    //tinfo200:[2020 - 03 - 12 - sonu - dykstra1]- enum for grade from a-f
    public enum Grade
    {
        A, B, C, D, F
    }

    //tinfo200:[2020 - 03 - 12 - sonu - dykstra1]- Created enrollment class which has the enrollmentid course id studnet id grade and the student 
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
    }
}