CREATE TABLE role(
  role_id SMALLINT(6) UNSIGNED NOT NULL AUTO_INCREMENT,
  role_name VARCHAR(100) NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(role_id),
  UNIQUE INDEX UQ_role_name(role_name)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;