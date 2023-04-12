using System;
using System.Collections;

namespace AppCode
{
    public class Person : IComparable<Person>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public double Phone {  get; set; }

        public Person()
        {

        }
        public Person(int id, string firstName,string lastName, string city, string state, int age, double phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            Age = age;
            Phone = phone;
        }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"{Id,-10}{FirstName,-12} {LastName,-12}{Age,-5}{State,-12}{City,-12}{Phone}";
        }
    }
}
