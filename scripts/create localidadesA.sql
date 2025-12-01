CREATE TABLE `Localidades` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Provincia` int(11) DEFAULT NULL,
  `nombre` varchar(150) DEFAULT NULL,
  `baja` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
