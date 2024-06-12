-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-06-2024 a las 19:50:53
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdcolores`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `textura`
--

CREATE TABLE `textura` (
  `id` int(11) NOT NULL,
  `descripcion_origen` varchar(255) NOT NULL,
  `cR_origen` int(11) NOT NULL,
  `cG_origen` int(11) NOT NULL,
  `cB_origen` int(11) NOT NULL,
  `hex_origen` varchar(7) NOT NULL,
  `descripcion_destino` varchar(255) NOT NULL,
  `cR_destino` int(11) NOT NULL,
  `cG_destino` int(11) NOT NULL,
  `cB_destino` int(11) NOT NULL,
  `hex_destino` varchar(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `textura`
--

INSERT INTO `textura` (`id`, `descripcion_origen`, `cR_origen`, `cG_origen`, `cB_origen`, `hex_origen`, `descripcion_destino`, `cR_destino`, `cG_destino`, `cB_destino`, `hex_destino`) VALUES
(1, 'Fucsia', 255, 0, 255, '#FF00FF', 'Fucsia Claro', 255, 0, 255, '#FF00FF'),
(2, 'Aguamarina', 127, 255, 212, '#7FFFD4', 'Aguamarina Claro', 127, 255, 212, '#7FFFD4'),
(3, 'Café', 165, 42, 42, '#A52A2A', 'Café Oscuro', 139, 69, 19, '#8B4513'),
(4, 'Naranja Oscuro', 151, 100, 81, '#976451', 'Rojo', 255, 0, 0, '#FF0000'),
(5, 'Verde Lima', 0, 255, 0, '#00FF00', 'Verde Lima Claro', 50, 205, 50, '#32CD32'),
(6, 'Lavanda', 230, 230, 250, '#E6E6FA', 'Lavanda Oscuro', 230, 230, 250, '#E6E6FA'),
(7, 'Negro', 0, 0, 0, '#000000', 'Gris', 128, 128, 128, '#808080'),
(8, 'Amarillo Limón', 255, 244, 79, '#FFF44F', 'Amarillo Limón Claro', 255, 244, 79, '#FFF44F'),
(9, 'Beige', 245, 245, 220, '#F5F5DC', 'Beige Claro', 245, 245, 220, '#F5F5DC'),
(10, 'Azul Acero', 70, 130, 180, '#4682B4', 'Azul Acero Claro', 70, 130, 180, '#4682B4'),
(11, 'Siena', 160, 82, 45, '#A0522D', 'Siena Oscuro', 139, 69, 19, '#8B4513'),
(12, 'Gris Plata', 192, 192, 192, '#C0C0C0', 'Gris Plata Claro', 192, 192, 192, '#C0C0C0'),
(13, 'Café Oscuro', 84, 61, 20, '#543D14', 'Verde', 0, 128, 0, '#008000'),
(14, 'Gris', 128, 128, 128, '#808080', 'Gris Claro', 192, 192, 192, '#C0C0C0'),
(15, 'Azul Cielo', 135, 206, 235, '#87CEEB', 'Azul Cielo Claro', 135, 206, 235, '#87CEEB'),
(16, 'Orquídea', 218, 112, 214, '#DA70D6', 'Orquídea Claro', 218, 112, 214, '#DA70D6'),
(17, 'Turquesa', 64, 224, 208, '#40E0D0', 'Turquesa Oscuro', 0, 206, 209, '#00CED1'),
(18, 'Púrpura', 128, 0, 128, '#800080', 'Púrpura Claro', 128, 0, 128, '#800080'),
(19, 'Cobre', 184, 115, 51, '#B87333', 'Cobre Oscuro', 139, 69, 19, '#8B4513'),
(20, 'Salmon', 250, 128, 114, '#FA8072', 'Salmon Claro', 255, 160, 122, '#FFA07A'),
(21, 'Naranja', 255, 165, 0, '#FFA500', 'Naranja Claro', 255, 165, 0, '#FFA500'),
(22, 'Marfil', 255, 255, 240, '#FFFFF0', 'Marfil Claro', 255, 255, 240, '#FFFFF0'),
(23, 'Verde Oliva', 107, 142, 35, '#6B8E23', 'Verde Oliva Claro', 107, 142, 35, '#6B8E23'),
(24, 'Morado', 128, 0, 128, '#800080', 'Morado Claro', 186, 85, 211, '#BA55D3'),
(25, 'Rosa', 255, 192, 203, '#FFC0CB', 'Rosa Claro', 255, 182, 193, '#FFB6C1'),
(26, 'Azul Marino', 0, 0, 128, '#000080', 'Azul Marino Claro', 0, 0, 205, '#0000CD'),
(27, 'Marrón', 165, 42, 42, '#A52A2A', 'Marrón Claro', 210, 105, 30, '#D2691E'),
(28, 'Verde Menta', 152, 255, 152, '#98FF98', 'Verde Menta Claro', 144, 238, 144, '#90EE90');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `textura`
--
ALTER TABLE `textura`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `textura`
--
ALTER TABLE `textura`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
