# Laboratory No.3

# Goals

- Understand what is an ORM and how to use it;
- Get more familiar with MVC pattern;
- Understand BusinessLogic pattern;

# Tasks

### Main requirements:

- Define one model;
- Implement basic Create, Read, Update, Delete operations for the defined model;

### Bonus points:
- 2 or more models are defined and there are some relations between them (FK, MtM...); `(2 pt)`
- Define an ImageField or something related in a model. Display the uploaded image in detail view; `(1 pt)`
- On the list view, implement some basic filtering (search field, etc...); `(1 pt)`


# Implementation

- To run the application, clone this project, open Visual Studio, and Build and Run (F5).

### Main Requirements:

– After deﬁning the ﬁrst model (__User__), I had to bust through the metal wall of errors and exceptions created by trying to connect to the server (and then by creating the database, the tables and also those goddamned Migrations that caused so much trouble, nearly made me throw my laptop out of the window and then throw myself too);

– After hours of enduring that torture, I managed to succeed somehow, and implemented some basic __CRUD__ (User creation done in the Registration Page, Reading in the Log In page, Updating in the Settings page - changing the password mostly for now, and the Delete Operation exists only for the Drawing model, which I added afterwards);

### Bonus Points:

– I added 2 models, for __User__ (Authentication, which I implemented even if it wasn’t in the tasks) and __Drawing__, they have a One to Many relationship (a User can have multiple drawings); `(2 pt)`

– Since it is not recommended to store in the database an __Image__, the drawings (made by users) are saved on the server, then the local paths to the images are transformed to URL paths, and saved in the database (alongside some information like title, description, ...). The saved images are then displayed in the Gallery; `(1 pt)`

– Every user can view their own drawings in their Proﬁle (the ﬁltering is made by _ImageUrl_ ﬁeld, since it’s as unique as the Id); `(1 pt)`

– Also, the drawings are created online, on a canvas and some basic drawing tools (there’s gonna be more in the near future).


# Conclusions
- It was a very agonizing experience which I hope to never encounter again. Period.
