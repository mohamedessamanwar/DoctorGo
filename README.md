# Doctor Go

Doctor Go is a healthcare platform designed to make healthcare services more accessible and user-friendly. Built using **.NET Core MVC**, the platform enables patients to easily find doctors, book appointments, and make secure online payments.

---

## 📌 **Table of Contents**

* [Introduction](#introduction)
* [Objectives](#objectives)
* [Features](#features)
* [Technologies Used](#technologies-used)
* [Architecture](#architecture)
* [User Journeys](#user-journeys)
* [Future Enhancements](#future-enhancements)
* [Setup Instructions](#setup-instructions)
* [Contributors](#contributors)

---

## 🚀 **Introduction**

**Doctor Go** aims to simplify patient-doctor interaction and streamline healthcare services through an easy-to-use online booking system and centralized appointment management.

---

## 🎯 **Objectives**

* **Improve Patient-Doctor Interaction:**
  Simplify appointment booking and allow patients to view detailed doctor profiles.

* **Streamline Healthcare Services:**
  Automate appointment management, payments, and notifications to reduce administrative tasks and increase efficiency.

---

## ✨ **Features**

### 👤 **Patients**

* Register & login
* Search for doctors by specialty, location, or name
* View detailed doctor profiles
* Book appointments and select time slots
* Make secure payments via **Stripe**
* Receive email notifications for booking confirmations
* Add feedback/comments for doctors

### 🩺 **Doctors**

* Login & manage their availability
* View upcoming appointments
* Receive booking notifications via email

### 🛠️ **Admins**

* Add/manage doctors & admins
* Manage specialties
* Monitor system activity
* Automated email notifications for new accounts

---

## ⚙️ **Technologies Used**

* **Frontend:**

  * HTML5, CSS3, JavaScript, Bootstrap

* **Backend:**

  * .NET Core MVC
  * Entity Framework Core
  * LINQ

* **Database:**

  * SQL Server

* **Payment Processing:**

  * Stripe Payment Gateway

* **Additional Services:**

  * Email Service for notifications

* **Architecture & Design Patterns:**

  * N-tier Architecture
  * Repository Pattern
  * Unit of Work Pattern

---

## 🗂️ **Architecture**

The project follows an **N-tier architecture** with clear separation of concerns, using Repository and Unit of Work patterns to handle data access and transactions.

---

## 👣 **User Journeys**

### Patients

1. Register & log in
2. Search & select doctor
3. Book appointment & pay securely
4. Receive confirmation email

### Doctors

1. Log in
2. Set/manage available time slots
3. View appointments & receive booking notifications

### Admins

1. Log in
2. Manage doctors, admins, and specialties
3. Monitor system activities

---

## 🔮 **Future Enhancements**

* **Social Login:** Sign in with Facebook or Gmail
* **Multi-Factor Authentication (MFA)** for enhanced security
* **Telemedicine:** Video/telephone consultations
* **AI Chatbot:** 24/7 support for basic health queries
* **Cash Payment Option**
* **Doctor Advertising System**
* **Dual Clinic Management**
* **Integration with Labs & Pharmacies**
* **Regular Health Check-up Packages**

---

## 🚦 **Setup Instructions**

1. Clone the repository.

   ```bash
   git clone https://github.com/your-username/doctor-go.git
   ```
2. Open the solution in **Visual Studio**.
3. Update **appsettings.json** with your **SQL Server** and **Stripe API keys**.
4. Run database migrations:

   ```bash
   dotnet ef database update
   ```
5. Build and run the project.
6. Open your browser and navigate to `https://localhost:xxxx`.

---

## 🤝 **Contributors**

* Amir Mustafa Ibrahim
* Ali Issam Abdel Halim
* Mohamed Essam Anwar
* Mohamed Ashraf Taher

**Supervisor:** Eng. Mohamed Ahmed Sayed

---

## 📧 **Contact**

For questions, please reach out to the team or open an issue in the repository.
