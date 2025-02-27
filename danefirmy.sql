-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 06 Lut 2025, 12:34
-- Wersja serwera: 10.4.27-MariaDB
-- Wersja PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `danefirmy`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klienci`
--

CREATE TABLE `klienci` (
  `IdKlienta` int(11) NOT NULL,
  `ImieKlienta` text NOT NULL,
  `NazwiskoKlienta` text NOT NULL,
  `OsobaKontaktowa` varchar(777) NOT NULL,
  `Adres` varchar(777) NOT NULL,
  `Miasto` text NOT NULL,
  `KodPocztowy` varchar(777) NOT NULL,
  `Kraj` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `klienci`
--

INSERT INTO `klienci` (`IdKlienta`, `ImieKlienta`, `NazwiskoKlienta`, `OsobaKontaktowa`, `Adres`, `Miasto`, `KodPocztowy`, `Kraj`) VALUES
(1, 'Łukasz', 'Kowalski', '345 678 123 - Tomasz Biały', 'Filmowa 43', 'Warszawa', '04-935', 'Polska'),
(2, 'Kacper', 'Miszalski', '234 43 67 89 - Paweł Woźny', 'Tadeusza Kościuszki 25/27', 'Sopot', '81-704', 'Polska'),
(3, 'Krzysztof', 'Nowak', '123 456 987 - Mateusz Kazimierski', 'Włościańska 1', 'Szczecin', '70-018', 'Polska'),
(4, 'Hans', 'Müller', '123 456 789 - Max Schmidt', 'Hauptstraße 1', 'Berlin', '10-115', 'Niemcy'),
(5, 'Anna', 'Schmidt', '234 567 890 - Lisa Müller', 'Fischmarkt 2', 'Hamburg', '20-457', 'Niemcy'),
(6, 'Peter', 'Klein', '345 678 901 - Anna Becker', 'Marienplatz 1', 'Monachium', '80-331', 'Niemcy'),
(7, 'Julien', 'Lefevre', '456 789 012 - Claire Dubois', 'Cours Belsunce 12', 'Marsylia', '13-001', 'Francja'),
(8, 'Sophie', 'Martin', '567 890 123 - Pierre Bernard', 'Rue de la République 25', 'Tuluza', '31-021', 'Francja'),
(9, 'Luc', 'Dupont', '678 901 234 - Émilie Laurent', 'Avenue Jean Médecin 45', 'Nicea', '06-010', 'Francja'),
(10, 'John', 'Smith', '789 012 345 - Sarah Johnson', '1600 Pennsylvania Ave NW', 'Waszyngton', '20-500', 'USA'),
(11, 'Emily', 'Garcia', '890 123 456 - David Martinez', 'Central Ave 123', 'Phoenix', '85-001', 'USA'),
(12, 'Michael', 'Brown', '901 234 567 - Laura Wilson', 'Michigan Ave 456', 'Chicago', '60-601', 'USA');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zamowienia`
--

CREATE TABLE `zamowienia` (
  `IdKlienta` int(11) DEFAULT NULL,
  `IdZamowienia` int(11) DEFAULT NULL,
  `DataZamowienia` date DEFAULT NULL,
  `Miasto` varchar(777) DEFAULT NULL,
  `WartoscZamowienia` double DEFAULT NULL,
  `Kraj` varchar(777) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `zamowienia`
--

INSERT INTO `zamowienia` (`IdKlienta`, `IdZamowienia`, `DataZamowienia`, `Miasto`, `WartoscZamowienia`, `Kraj`) VALUES
(1, 1, '2025-02-06', 'Kielce', 5000, 'Polska'),
(2, 2, '2025-02-06', 'Białystok', 3200, 'Polska'),
(3, 3, '2025-02-06', 'Gorzów Wielkopolski', 4500, 'Polska'),
(4, 4, '2025-02-06', 'Kolonia', 7000, 'Niemcy'),
(5, 5, '2025-02-06', 'Stuttgart', 6000, 'Niemcy'),
(6, 6, '2025-02-06', 'Frankfurt', 5200, 'Niemcy'),
(7, 7, '2025-02-06', 'Paryż', 8000, 'Francja'),
(8, 8, '2025-02-06', 'Bordeaux', 6700, 'Francja'),
(9, 9, '2025-02-06', 'Lille', 5500, 'Francja'),
(10, 10, '2025-02-06', 'Chicago', 12000, 'USA'),
(11, 11, '2025-02-06', 'Atlanta', 11000, 'USA'),
(12, 12, '2025-02-06', 'Los Angeles', 9500, 'USA');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `klienci`
--
ALTER TABLE `klienci`
  ADD PRIMARY KEY (`IdKlienta`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `klienci`
--
ALTER TABLE `klienci`
  MODIFY `IdKlienta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
