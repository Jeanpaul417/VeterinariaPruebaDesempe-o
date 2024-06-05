/* Propietarios */
CREATE TABLE Owners (
  id INTEGER PRIMARY KEY AUTO_INCREMENT,
  Names VARCHAR(50),
  LastNames VARCHAR(50),
  Email VARCHAR(100),
  Address VARCHAR(50),
  Phone VARCHAR(25)
)


/* Mascotas */
CREATE TABLE Pets (
  id INTEGER PRIMARY KEY AUTO_INCREMENT,
  Name VARCHAR(125),
  Specie ENUM("dog", "cat", "rabbit","hamster"),
  Race ENUM("creole", "purebred", "other"),
  DateBrith DATE,
  OwnerId INTEGER,
  Phote TEXT,
  FOREIGN KEY (OwnerId) REFERENCES Owners(id)
  )


  /* Veterinarios */
  CREATE TABLE Vets (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(120),
    Phone VARCHAR(25),
    Address VARCHAR(30),
    Email VARCHAR(100)
  )

  /* Citas */

    CREATE TABLE Quotes (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Date DATE,
    PetId INTEGER,
    VetId INTEGER,
    Description TEXT,
    FOREIGN KEY (PetId) REFERENCES Pets(id),
    FOREIGN KEY (VetId) REFERENCES Vets(id)
  )