
## Содержание 
- [Создание новой базы данных](#создание-новой-базы-данных)
- [Создание таблиц](#создание-таблиц)
    - [Таблица "факультеты"](#таблица-факультеты)
    - [Таблица "кафедры"](#таблица-кафедры)
    - [Таблица "группы студентов"](#таблица-группы-студентов)
    - [Таблица "студенты"](#таблица-студенты)
    - [Таблица "успеваемость"](#таблица-успеваемость)
- [Заполнение таблицы](#заполнение-таблиц-данными)
    - [Таблица "факультеты"](#факультеты)
    - [Таблица "кафедры"](#кафедры)
    - [Таблица "группы студентов"](#группы-студентов)
    - [Таблица "студенты"](#студенты)
    - [Таблица "успеваемость"](#успеваемость)
- [Установка первичных и внешних ключей](#установка-первичных-и-внешних-ключей) 
    - [Таблицы "факультеты" и "кафедры"](#таблицы-факультеты-и-кафедры)
    - [Таблицы "кафедры" и "группы студентов"](#таблицы-кафедры-и-группы-студентов)
    - [Таблицы "группы студентов" и "студенты"](#таблицы-группы-студентов-и-студенты)
    - [Таблицы "группы студентов" и "успеваемость"](#таблицы-группы-студентов-и-успеваемость)
    - [Таблицы "студенты" и "успеваемость"](#таблицы-студенты-и-успеваемость)
- [Модели](#модели)
    - [Концептуальная модель](#концептуальная-модель)
    - [ER-модель](#er-модель)
    - [ERD-модель](#erd-модель)

---

## Создание новой базы данных

Жмём на созданного пользователя откроется список, необходимо нажать на параметр **Databases** правой кнопкой мыши и выбираем параметр **Create** -> **Database...**

![Создание новой базы данных](images/1.png "Создание новой базы данных")

---

Далее откроется окно создания базы данных. Необходимо задать название для неё. Вводим *homework_2* и нажимаем **Save**.

![Создание новой базы данных](images/2.png "Создание новой базы данных")

## Создание таблиц

Открываем **Query Tool** в **pgAdmin** с помощью правой кнопки мыши, кликнув по названию базы данных (*homework_2*).

![Открываем Query Tool](images/3.png "Открываем Query Tool")

---

Необходимо создать 5 таблиц: **факультеты**, **кафедра**, **учебные группы**, **студенты**, **успеваемость**. 
В новом окне вводим запросы и нажимаем выполнить (*F5*): 

### Таблица "факультеты"

```
CREATE TABLE FACULTIES
(
    FACULTY_NAME VARCHAR(100),
	DEAN_FIO VARCHAR(100),
	ROOM_NUMBER INTEGER,
	BUILDING_NUMBER INTEGER,
	PHONE_NUMBER BIGINT
);
```

![Создание таблиц](images/4.png "Создание таблиц")

---

### Таблица "кафедры"

```
CREATE TABLE DEPARTMENTS
(
	DEPARTMENT_NAME VARCHAR(100),
	FACULTY VARCHAR(100),
	MANAGER_FULL_NAME VARCHAR(100),
	ROOM_NUMBER INTEGER,
	BUILDING_NUMBER INTEGER,
	PHONE_NUMBER BIGINT,
	TEACHER_COUNT INTEGER
);
```

![Создание таблиц](images/5.png "Создание таблиц")

---

### Таблица "группы студентов"

```
CREATE TABLE STUDY_GROUPS
(
	DEPARTMENT_NAME VARCHAR(100),
	GROUP_NUMBER INTEGER,
	ADMISSION_YEAR INTEGER,
	STUDY_COURSE INTEGER,
	STUDENTS_NUMBER INTEGER
);
```

![Создание таблиц](images/6.png "Создание таблиц")

---

### Таблица "студенты"

```
CREATE TABLE STUDENTS
(
	STUDENT_ID INTEGER,
	STUDENT_SURNAME VARCHAR(100),
	STUDENT_NAME VARCHAR(100),
	STUDENT_PATRONYMIC VARCHAR(100),
	GROUP_NUMBER INTEGER,
	GENDER VARCHAR(10),
	ADDRESS VARCHAR(100),
	CITY VARCHAR(100),
	PHONE_NUMBER BIGINT
);
```

![Создание таблиц](images/7.png "Создание таблиц")

---
### Таблица "успеваемость"

```
CREATE TABLE PROGRESS
(
	GROUP_NUMBER INTEGER,
	STUDENT_ID INTEGER,
	SUBJECT VARCHAR(30),
	MARK INTEGER
);
```

![Создание таблиц](images/8.png "Создание таблиц")
---

Проверим наличие таблиц. Нажимаем **Schemas** -> **Tables** и видим, что все таблицы были действительно созданы. 

![Создание таблиц](images/9.png "Создание таблиц")

---

## Заполнение таблиц данными

Чтобы заполнить таблицу данными, необходимо снова открыть **Query Tool**  (см. [создание таблиц](#создание-таблиц)).

Заполняем все таблицы по порядку.
Вводим запросы и нажимаем выполнить (*F5*):

---

### "Факультеты"

```
INSERT INTO FACULTIES VALUES('HISTORY', 'SIDOROV N.V', 209, 2, 89656242971);
INSERT INTO FACULTIES VALUES('PHYSICS', 'NOVIKOV A.T', 404, 1, 89656234955);
INSERT INTO FACULTIES VALUES('CHEMISTRY', 'SIDIKOV V.L', 212, 4, 89446421955);
INSERT INTO FACULTIES VALUES('ECONOMICS', 'BULAKOV R.K', 1502, 12, 89446421475);
INSERT INTO FACULTIES VALUES('MATHEMATICS', 'HAFIZOV E.R', 310, 9, 89439121466);
```
![Заполнение таблицы](images/10.png "Заполнение таблицы")

---

### "Кафедры"

```
INSERT INTO DEPARTMENTS VALUES('HISTORY OF RUSSIA', 'HISTORY', 'IVANOV A.I', 156, 2, 89178234561, 7);
INSERT INTO DEPARTMENTS VALUES('PHYSICS OF MOLECULAR SYSTEMS', 'PHYSICS', 'SMIRNOV E.R', 16, 1, 89196351325, 5);
INSERT INTO DEPARTMENTS VALUES('ORGANIC AND MEDICINAL CHEMISTRY', 'CHEMISTRY', 'PETROVA V.I', 345, 4, 89172095417, 3);
INSERT INTO DEPARTMENTS VALUES('ECONOMICS OF PRODUCTION', 'ECONOMICS', 'BULAKOV R.K', 1502, 12, 89446421475, 6);
INSERT INTO DEPARTMENTS VALUES('GEOMETRY', 'MATHEMATICS', 'HAFIZOV E.R', 310, 9, 89439121466, 4);

```

![Заполнение таблицы](images/11.png "Заполнение таблицы")

---

### "Группы студентов"

```
INSERT INTO STUDY_GROUPS VALUES('HISTORY OF RUSSIA', 143, 2020, 4, 20);
INSERT INTO STUDY_GROUPS VALUES('PHYSICS OF MOLECULAR SYSTEMS', 201, 2022, 2, 23);
INSERT INTO STUDY_GROUPS VALUES('ORGANIC AND MEDICINAL CHEMISTRY', 103, 2021, 3, 18);
INSERT INTO STUDY_GROUPS VALUES('ECONOMICS OF PRODUCTION', 208, 2023, 1, 28);
INSERT INTO STUDY_GROUPS VALUES('GEOMETRY', 379, 2023, 1, 32);

```

![Заполнение таблицы](images/12.png "Заполнение таблицы")

---

### "Студенты"

```
INSERT INTO STUDENTS VALUES(1, 'IVANOV', 'SERGEY', 'VLADIMIROVICH', 143, 'MALE', 'POBEDY AVENUE, 32', 'KAZAN', 89175328132);
INSERT INTO STUDENTS VALUES(2, 'SIDOROV', 'IVAN', 'ALEKSEEVICH', 143, 'MALE', 'POBEDY AVENUE, 18', 'KAZAN', 89175568737);
INSERT INTO STUDENTS VALUES(3, 'MAKAROVA', 'MARIA', 'VIKTOROVNA', 143, 'FEMALE', 'KUL GALI STREET, 5', 'KAZAN', 89195463191);

INSERT INTO STUDENTS VALUES(4, 'SMIRNOV', 'BORIS', 'IGOREVICH', 201, 'MALE', 'KUL GALI STREET, 43', 'KAZAN', 89652947143);
INSERT INTO STUDENTS VALUES(5, 'FEDOTOV', 'IVAN', 'ALEKSANDROVICH', 201, 'MALE', 'RODINY STREET, 27', 'KAZAN', 89674152017);
INSERT INTO STUDENTS VALUES(6, 'BARINOVA', 'ALINA', 'MIKHAILOVNA', 201, 'FEMALE', 'RODINY STREET, 89', 'KAZAN', 89194562238);

INSERT INTO STUDENTS VALUES(7, 'CVETKOV', 'MARK', 'SERGEEVICH', 103, 'MALE', 'CHETAEVA STREET, 24', 'KAZAN', 89165374513);
INSERT INTO STUDENTS VALUES(8, 'RODIONOV', 'NIKITA', 'PAVLOVICH', 103, 'MALE', 'CHETAEVA STREET, 44', 'KAZAN', 89153481267);
INSERT INTO STUDENTS VALUES(9, 'IVANOVA', 'ALISA', 'MARKOVNA', 103, 'FEMALE', 'RODINY STREET, 56', 'KAZAN', 89197629183);

INSERT INTO STUDENTS VALUES(10, 'SIMONOV', 'IGOR', 'SERGEEVICH', 208, 'MALE', 'PUSHKINA STREET, 24', 'KAZAN', 89163501427);
INSERT INTO STUDENTS VALUES(11, 'KARIMOV', 'TIMUR', 'IVANOVICH', 208, 'MALE', 'PUSHKINA STREET, 27', 'KAZAN', 89196574219);
INSERT INTO STUDENTS VALUES(12, 'PETROV', 'KIRILL', 'ALEKSEEVICH', 208, 'MALE', 'PUSHKINA STREET, 98', 'KAZAN', 89174591526);

INSERT INTO STUDENTS VALUES(13, 'SMIRNOV', 'IGOR', 'MIKHAILOVICH', 379, 'MALE', 'KUL GALI STREET, 24', 'KAZAN', 89165761946);
INSERT INTO STUDENTS VALUES(14, 'IVANOV', 'BORIS', 'VLADIMIROVICH', 379, 'MALE', 'KUL GALI STREET, 56', 'KAZAN', 89165891716);
INSERT INTO STUDENTS VALUES(15, 'FEDOTOV', 'TIMUR', 'MARKOVICH', 379, 'MALE', 'KUL GALI STREET, 12', 'KAZAN', 89196549132);
```

![Заполнение таблицы](images/13.png "Заполнение таблицы")

---

### "Успеваемость"

```
INSERT INTO PROGRESS VALUES(143, 1, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(143, 1, 'GEOMETRY', 4);
INSERT INTO PROGRESS VALUES(143, 1, 'CHEMISTRY', 5);

INSERT INTO PROGRESS VALUES(143, 2, 'HISTORY OF RUSSIA', 3);
INSERT INTO PROGRESS VALUES(143, 2, 'GEOMETRY', 5);
INSERT INTO PROGRESS VALUES(143, 2, 'CHEMISTRY', 4);

INSERT INTO PROGRESS VALUES(143, 3, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(143, 3, 'GEOMETRY', 5);
INSERT INTO PROGRESS VALUES(143, 3, 'CHEMISTRY', 4);


INSERT INTO PROGRESS VALUES(201, 4, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(201, 4, 'ALGEBRA', 4);
INSERT INTO PROGRESS VALUES(201, 4, 'PHYSICS', 5);

INSERT INTO PROGRESS VALUES(201, 5, 'HISTORY OF RUSSIA', 3);
INSERT INTO PROGRESS VALUES(201, 5, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(201, 5, 'PHYSICS', 4);

INSERT INTO PROGRESS VALUES(201, 6, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(201, 6, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(201, 6, 'PHYSICS', 4);


INSERT INTO PROGRESS VALUES(103, 7, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(103, 7, 'ALGEBRA', 4);
INSERT INTO PROGRESS VALUES(103, 7, 'ECONOMICS', 5);

INSERT INTO PROGRESS VALUES(103, 8, 'HISTORY OF RUSSIA', 3);
INSERT INTO PROGRESS VALUES(103, 8, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(103, 8, 'ECONOMICS', 4);

INSERT INTO PROGRESS VALUES(103, 9, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(103, 9, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(103, 9, 'ECONOMICS', 4);


INSERT INTO PROGRESS VALUES(208, 10, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(208, 10, 'ALGEBRA', 4);
INSERT INTO PROGRESS VALUES(208, 10, 'ECONOMICS', 5);

INSERT INTO PROGRESS VALUES(208, 11, 'HISTORY OF RUSSIA', 3);
INSERT INTO PROGRESS VALUES(208, 11, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(208, 11, 'ECONOMICS', 4);

INSERT INTO PROGRESS VALUES(208, 12, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(208, 12, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(208, 12, 'ECONOMICS', 4);


INSERT INTO PROGRESS VALUES(379, 13, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(379, 13, 'ALGEBRA', 4);
INSERT INTO PROGRESS VALUES(379, 13, 'PHYSICS', 5);

INSERT INTO PROGRESS VALUES(379, 14, 'HISTORY OF RUSSIA', 3);
INSERT INTO PROGRESS VALUES(379, 14, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(379, 14, 'PHYSICS', 4);

INSERT INTO PROGRESS VALUES(379, 15, 'HISTORY OF RUSSIA', 5);
INSERT INTO PROGRESS VALUES(379, 15, 'ALGEBRA', 5);
INSERT INTO PROGRESS VALUES(379, 15, 'PHYSICS', 4);
```

![Заполнение таблицы](images/14.png "Заполнение таблицы")
![Заполнение таблицы](images/15.png "Заполнение таблицы")

>На стадии заполнения таблиц может возникнуть проблема с типом данных для столбцов, а также некоторые данные могут не уместиться в 100 символов, чтобы это исправить, необходимо нажать правой кнопкой мыши по названию таблицы -> **Properties** -> **Column** и изменить тип данных для стобца.
> 
> ![Редактирование таблицы](images/16.png "Редактирование таблицы")
> ![Редактирование таблицы](images/17.png "Редактирование таблицы")

---

## Установка первичных и внешних ключей

После заполнения таблиц значениями, необходимо расставить первичные ключи для таблиц, а затем уже и внешние. Установка первичных ключей выполняется запросом: 

### Таблицы "факультеты" и "кафедры"

```
ALTER TABLE FACULTIES
ADD CONSTRAINT unique_faculty_name UNIQUE (FACULTY_NAME);
```

![Установка первичного ключа для таблицы](images/18.png "Установка первичного ключа для таблицы")

Далее установим внешний ключ для этой таблицы:

```
ALTER TABLE DEPARTMENTS
ADD CONSTRAINT fk_department_faculty
FOREIGN KEY (FACULTY)
REFERENCES FACULTIES (FACULTY_NAME);
```

![Установка внешнего ключа для таблицы](images/19.png "Установка внешнего ключа для таблицы")

Проделываем то же самое для других таблиц:

---

### Таблицы "кафедры" и "группы студентов"

```
ALTER TABLE DEPARTMENTS
ADD CONSTRAINT unique_department_name UNIQUE (DEPARTMENT_NAME);
```

![Установка первичного ключа для таблицы](images/20.png "Установка первичного ключа для таблицы")

```
ALTER TABLE STUDY_GROUPS
ADD CONSTRAINT fk_department_id
FOREIGN KEY (DEPARTMENT_ID)
REFERENCES DEPARTMENTS (DEPARTMENT_NAME);
```

![Установка внешнего ключа для таблицы](images/21.png "Установка внешнего ключа для таблицы")

---

### Таблицы "группы студентов" и "студенты"

```
ALTER TABLE STUDY_GROUPS
ADD CONSTRAINT uk_group_number
UNIQUE (GROUP_NUMBER);
```

![Установка первичного ключа для таблицы](images/22.png "Установка первичного ключа для таблицы")

```
ALTER TABLE STUDENTS
ADD CONSTRAINT fk_group_number
FOREIGN KEY (GROUP_NUMBER)
REFERENCES STUDY_GROUPS (GROUP_NUMBER);
```

![Установка внешнего ключа для таблицы](images/23.png "Установка внешнего ключа для таблицы")

---

### Таблицы "группы студентов" и "успеваемость"

```
ALTER TABLE PROGRESS
ADD CONSTRAINT fk_group_number
FOREIGN KEY (GROUP_NUMBER)
REFERENCES STUDY_GROUPS (GROUP_NUMBER);
```

![Установка внешнего ключа для таблицы](images/24.png "Установка внешнего ключа для таблицы")

---

### Таблицы "студенты" и "успеваемость"

```
ALTER TABLE STUDENTS
ADD CONSTRAINT uk_srtudent_id UNIQUE (STUDENT_ID);
```

![Установка первичного ключа для таблицы](images/25.png "Установка первичного ключа для таблицы")

```
ALTER TABLE PROGRESS
ADD CONSTRAINT fk_student_id
FOREIGN KEY (STUDENT_ID)
REFERENCES STUDENTS (STUDENT_ID);
```

![Установка внешнего ключа для таблицы](images/26.png "Установка внешнего ключа для таблицы")

---

## Модели 

### Концептуальная модель

![Концептуальная модель](images/31.png "Концептуальная модель")

---

### ER-модель

Чтобы посмотреть итоговую **ERD-модель** для базы данных нажимаем правой кнопкой мыши на название базы данных (*homework_2*) и выбираем **ERD For Database**.

![ER-модель](images/27.png "ER-модель")

В открывшемся окне необходимо выбрать параматер *Cardinality Notation* -> *Chen Notation* (5-й с конца).

![ER-модель](images/30.png "ER-модель")

![ER-модель](images/29.png "ER-модель")

---

### ERD-модель

Чтобы посмотреть итоговую **ERD-модель** для базы данных нажимаем правой кнопкой мыши на название базы данных (*homework_2*) и выбираем **ERD For Database**.

![ERD-модель](images/27.png "ERD-модель")

![ERD-модель](images/28.png "ERD-модель")

---
