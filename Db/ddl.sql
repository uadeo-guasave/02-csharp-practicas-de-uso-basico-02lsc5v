-- Data Definition Language Sqlite
CREATE TABLE roles (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name VARCHAR(16) NOT NULL UNIQUE,
  description VARCHAR(200) NOT NULL,
  level INTEGER NOT NULL
);

CREATE TABLE permissions (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name VARCHAR(16) NOT NULL UNIQUE,
  description VARCHAR(200) NOT NULL
);

CREATE TABLE roles_has_permissions (
  role_id INTEGER NOT NULL,
  permission_id INTEGER NOT NULL,
  PRIMARY KEY (role_id, permission_id),
  CONSTRAINT fk_rhp_roles
    FOREIGN KEY (role_id)
    REFERENCES roles(id)
      ON UPDATE CASCADE
      ON DELETE RESTRICT,
  CONSTRAINT fk_rhp_permissions
    FOREIGN KEY (permission_id)
    REFERENCES permissions(id)
      ON UPDATE CASCADE
      ON DELETE RESTRICT
);

CREATE TABLE users (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name VARCHAR(16) NOT NULL UNIQUE,
  password VARCHAR(200) NOT NULL,
  firstname VARCHAR(50) NOT NULL,
  lastname VARCHAR(50) NOT NULL,
  email VARCHAR(200) NOT NULL UNIQUE,
  remember_token VARCHAR(200) DEFAULT NULL,
  gender INTEGER NOT NULL,
  role_id INTEGER NOT NULL,
  CONSTRAINT fk_users_roles
    FOREIGN KEY (role_id)
    REFERENCES roles(id)
      ON UPDATE CASCADE
      ON DELETE RESTRICT
);