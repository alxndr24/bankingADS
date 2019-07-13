CREATE TABLE movement(
  movement_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  account_id BIGINT(20) UNSIGNED NOT NULL,
  account_destino_id BIGINT(20) UNSIGNED NOT NULL,
  balance DECIMAL(10,2) NOT NULL, 
  movement_type_id SMALLINT(6) UNSIGNED NOT NULL,
  created_at_utc DATETIME NOT NULL, 
  PRIMARY KEY(movement_id), 
  CONSTRAINT FK_movement_account_id FOREIGN KEY(account_id) REFERENCES account(account_id),
  CONSTRAINT FK_movement_account_destino_id FOREIGN KEY(account_destino_id) REFERENCES account(account_id),
  CONSTRAINT FK_movement_movement_type_id FOREIGN KEY(movement_type_id) REFERENCES movement_type(movement_type_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;