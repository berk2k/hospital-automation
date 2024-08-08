using Microsoft.VisualStudio.TestTools.UnitTesting;
using hospital_automation.models;
using hospital_automation.service;
using System.Collections.Generic;

namespace HospitalAutomation.Tests
{
    [TestClass]
    public class SurgeryServiceTests
    {
        private SurgeryService _surgeryService;

        [TestInitialize]
        public void Setup()
        {
            _surgeryService = new SurgeryService();
        }

        [TestMethod]
        public void IsDoctorCountValid_WithOneDoctor_ReturnsTrue()
        {
            // Arrange
            var surgery = new Surgery(10, 50, 1, 3);

            // Act
            var result = _surgeryService.IsDoctorCountValid(surgery);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNurseCountValid_WithFiveNurses_ReturnsTrue()
        {
            // Arrange
            var surgery = new Surgery(10, 50, 1, 5);

            // Act
            var result = _surgeryService.IsNurseCountValid(surgery);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanPatientHaveASurgery_WithNoAnnualSurgeries_ReturnsTrue()
        {
            // Arrange
            var patient = new Patient("Alice", 0, 2, 10);

            // Act
            var result = _surgeryService.CanPatientHaveASurgery(patient);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanPatientBookACheckUp_WithLessThanThreeMonthlyCheckups_ReturnsTrue()
        {
            // Arrange
            var patient = new Patient("Alice", 0, 2, 10);

            // Act
            var result = _surgeryService.CanPatientBookACheckUp(patient);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MostCheckUpPatientName_WithEmptyList_ThrowsInvalidOperationException()
        {
            // Arrange
            var patients = new List<Patient>();

            // Act
            _surgeryService.MostCheckUpPatientName(patients);
        }

        [TestMethod]
        public void MostCheckUpPatientName_WithPatients_ReturnsCorrectPatient()
        {
            // Arrange
            var patient1 = new Patient("Alice", 0, 2, 10);
            var patient2 = new Patient("Bob", 1, 3, 20);
            var patient3 = new Patient("Charlie", 0, 1, 15);
            var patients = new List<Patient> { patient1, patient2, patient3 };

            // Act
            var result = _surgeryService.MostCheckUpPatientName(patients);

            // Assert
            Assert.AreEqual(patient2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MostSurgeryCost_WithEmptyList_ThrowsInvalidOperationException()
        {
            // Arrange
            var surgeries = new List<Surgery>();
            var doctor = new Doctor("Dr. Smith", Doctor.Role.OPERATOR, 500);

            // Act
            _surgeryService.MostSurgeryCost(surgeries, doctor);
        }

        [TestMethod]
        public void MostSurgeryCost_WithSurgeries_ReturnsHighestCost()
        {
            // Arrange
            var surgery1 = new Surgery(10, 50, 2, 3);
            var surgery2 = new Surgery(5, 100, 1, 4);
            var surgeries = new List<Surgery> { surgery1, surgery2 };
            var doctor = new Doctor("Dr. Smith", Doctor.Role.OPERATOR, 500);

            // Act
            var result = _surgeryService.MostSurgeryCost(surgeries, doctor);

            // Assert
            var expectedCost = (surgery2.GetSurgeryItemCount() * surgery2.GetItemFee()) + doctor.getDoctorFee();
            Assert.AreEqual(expectedCost, result);
        }
    }
}
