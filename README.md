# 📚 Application Development Project – 6th Semester

This repository contains the source code and documentation for my 6th semester **Application Development Project**, developed as part of the BS Computer Science degree at **PIEAS University**.

---

## 🚀 Project Overview

> A web-based platform where students can find, connect, and schedule sessions with professional tutors across different subjects and languages.

---

## ✨ Key Features

- 🔐 User authentication (login/signup)
- 👤 Role-based access (Admin, Tutor, Student)
- 📘 Course and language catalog
- 📅 Session scheduling and tracking
- 💬 Ratings and reviews
- 💵 Payment handling (mock/dummy)
- 📄 Database management with normalization

---

## ⚙️ Tech Stack

| Technology       | Purpose                        |
|------------------|--------------------------------|
| **HTML/CSS/JS**  | Frontend                       |
| **VB.NET WebForms** | Backend programming            |
| **Oracle 10g**   | Relational database management |
| **Visual Studio**| Development environment        |
| **ViewState**    | UI state management (ASP.NET)  |

---

## 🧱 Database Schema (Simplified)

- `STUDENT4(id, name, email, address, profile_desc)`
- `TUTORS(id, name, email, bio, hourly_rate, experience)`
- `COURSE9(course_name, description)`
- `LANGUAGE1(language_name, description)`
- `REVIEW_NEW(student_id, tutor_id, course_id, rating, comment)`
- `SCHEDULE_SESSIONS(session_date, time, duration, status)`
- `STUDENT_COURSE_LANGUAGE(...)`
- `TUTOR_COURSE_LANGUAGE(...)`

---

## 💻 How to Run

1. Open the `.sln` file in **Visual Studio**.
2. Ensure IIS Express or local server is enabled.
3. Run the project.
4. Use predefined sample users to log in or register a new user.

---

## 📝 Future Improvements

- Add live chat between tutor and student
- Email confirmation and password reset
- Integrate actual payment gateway
- Convert WebForms to modern **ASP.NET Core MVC**

---

## 👨‍🎓 Developer
## 👨‍🎓 Developer

**Syed Hassan Raza**  
BS Computer Science – PIEAS University  
Semester 6 Project – Application Development  
[LinkedIn: www.linkedin.com/in/syed-hassan-raza-ba842b277](https://www.linkedin.com/in/syed-hassan-raza-ba842b277)

---

## 📃 License

This project is open for learning and academic sharing purposes only.
