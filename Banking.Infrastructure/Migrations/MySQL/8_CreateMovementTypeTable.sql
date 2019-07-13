CREATE TABLE movement_type(
  movement_type_id SMALLINT(6) UNSIGNED NOT NULL AUTO_INCREMENT, 
  movement_type VARCHAR(50) NOT NULL,
  created_at_utc DATETIME NOT NULL, 
  PRIMARY KEY(movement_type_id),
  UNIQUE INDEX UQ_movement_type(movement_type)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;