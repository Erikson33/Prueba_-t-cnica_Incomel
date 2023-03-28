-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-03-2023 a las 02:36:28
-- Versión del servidor: 10.4.27-MariaDB
-- Versión de PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `pruebadb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `IDEMPLEADO` int(11) NOT NULL,
  `DPI` varchar(45) NOT NULL,
  `NOMBRECOMPLETO` varchar(45) NOT NULL,
  `CANT_HIJOS` int(11) NOT NULL,
  `SALARIOBASE` double(11,2) NOT NULL,
  `BONODECRETO` double(11,2) NOT NULL DEFAULT 250.00,
  `IDUSUARIO` int(11) NOT NULL,
  `FECHACREACION` datetime DEFAULT current_timestamp(),
  `IGSS` double(11,2) DEFAULT NULL,
  `IRTRA` double(11,2) DEFAULT NULL,
  `BONOPATERNIDAD` double(11,2) DEFAULT NULL,
  `SALARIO_TOTAL` double(11,2) DEFAULT NULL,
  `SALARIO_LIQUIDO` double(11,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`IDEMPLEADO`, `DPI`, `NOMBRECOMPLETO`, `CANT_HIJOS`, `SALARIOBASE`, `BONODECRETO`, `IDUSUARIO`, `FECHACREACION`, `IGSS`, `IRTRA`, `BONOPATERNIDAD`, `SALARIO_TOTAL`, `SALARIO_LIQUIDO`) VALUES
(1, '1234567890098', 'Luis Hernandez Lopez', 2, 3400.00, 250.00, 1, '2023-03-27 18:20:27', 164.22, 34.00, 266.00, 3916.00, 3717.78),
(2, '098765432123', 'Emilio Figeroa Coronado', 3, 3600.00, 250.00, 1, '2023-03-27 18:21:34', 173.88, 36.00, 399.00, 4249.00, 4039.12),
(3, '1029384756567', 'José Ramírez Sanches ', 1, 3500.00, 250.00, 1, '2023-03-27 18:22:26', 169.05, 35.00, 133.00, 3883.00, 3678.95),
(4, '2901378647465', 'Ana Salazar Flores', 4, 3450.00, 250.00, 2, '2023-03-27 18:24:35', 166.64, 34.50, 532.00, 4232.00, 4030.86),
(5, '3232378221223', 'Claudia Torres Orozco', 2, 3600.00, 250.00, 2, '2023-03-27 18:25:11', 173.88, 36.00, 266.00, 4116.00, 3906.12);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `IDUSUARIO` int(11) NOT NULL,
  `NOMBRE` varchar(45) NOT NULL,
  `EMAIL` varchar(45) NOT NULL,
  `FECHA_NACIMIENTO` date NOT NULL,
  `CONTRASEÑA` varchar(200) NOT NULL,
  `TOKEN_RECOVERY` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`IDUSUARIO`, `NOMBRE`, `EMAIL`, `FECHA_NACIMIENTO`, `CONTRASEÑA`, `TOKEN_RECOVERY`) VALUES
(1, 'Erikson Samayoa', 'testdesarrollo573@gmail.com', '2001-04-25', 'V62gyZH430VMAUGSwzIQZvhnQRdvuOA5', NULL),
(2, 'Carlos Arana Robles', 'Carlos@gmail.com', '2002-06-12', 'V62gyZH430VBMuQNOCdKOw==', NULL),
(3, 'Aurelio Valdez', 'ericksonsamayoa5@gmail.com', '2005-04-05', '4321', NULL);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`IDEMPLEADO`),
  ADD UNIQUE KEY `DPI` (`DPI`),
  ADD KEY `IDUSUARIO` (`IDUSUARIO`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`IDUSUARIO`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `IDEMPLEADO` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `IDUSUARIO` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`IDUSUARIO`) REFERENCES `usuario` (`IDUSUARIO`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
