CREATE TABLE role_permission(
  role_permission_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  role_id SMALLINT(6) UNSIGNED NOT NULL,
  permission_id SMALLINT(6) UNSIGNED NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(role_permission_id),
  UNIQUE INDEX UQ_role_permission_role_id_permission_id(role_id, permission_id),
  INDEX IX_role_permission_role_id(role_id),
  INDEX IX_role_permission_permission_id(permission_id),
  CONSTRAINT FK_role_permission_role_id FOREIGN KEY(role_id) REFERENCES role(role_id),
  CONSTRAINT FK_role_permission_permission_id FOREIGN KEY(permission_id) REFERENCES permission(permission_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;