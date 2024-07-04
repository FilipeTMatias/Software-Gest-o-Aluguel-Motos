--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-07-04 12:17:17

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "dbRentVehiclesManagement";
--
-- TOC entry 4856 (class 1262 OID 16398)
-- Name: dbRentVehiclesManagement; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "dbRentVehiclesManagement" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';


ALTER DATABASE "dbRentVehiclesManagement" OWNER TO postgres;

\connect "dbRentVehiclesManagement"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4857 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 16418)
-- Name: REGDRIVERLICENSETYPE; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGDRIVERLICENSETYPE" (
    "ID" integer NOT NULL,
    "DRIVER_LICENSE_TYPE" text NOT NULL,
    "AVAILABLE" boolean NOT NULL
);


ALTER TABLE public."REGDRIVERLICENSETYPE" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16417)
-- Name: REGDRIVERLICENSETYPE_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGDRIVERLICENSETYPE_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGDRIVERLICENSETYPE_ID_seq" OWNER TO postgres;

--
-- TOC entry 4858 (class 0 OID 0)
-- Dependencies: 219
-- Name: REGDRIVERLICENSETYPE_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGDRIVERLICENSETYPE_ID_seq" OWNED BY public."REGDRIVERLICENSETYPE"."ID";


--
-- TOC entry 224 (class 1259 OID 16445)
-- Name: REGPLANPRICES; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGPLANPRICES" (
    "ID" integer NOT NULL,
    "DESCRIPTION" text NOT NULL,
    "TOTAL_DAYS" integer NOT NULL,
    "PRICE" numeric NOT NULL
);


ALTER TABLE public."REGPLANPRICES" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16444)
-- Name: REGPLANPRICES_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGPLANPRICES_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGPLANPRICES_ID_seq" OWNER TO postgres;

--
-- TOC entry 4859 (class 0 OID 0)
-- Dependencies: 223
-- Name: REGPLANPRICES_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGPLANPRICES_ID_seq" OWNED BY public."REGPLANPRICES"."ID";


--
-- TOC entry 218 (class 1259 OID 16409)
-- Name: REGUSERS; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGUSERS" (
    "ID" integer NOT NULL,
    "USER" text NOT NULL,
    "NAME" text NOT NULL,
    "PASSWORD" text NOT NULL,
    "ID_PROFILE" integer NOT NULL
);


ALTER TABLE public."REGUSERS" OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16427)
-- Name: REGUSERSDRIVERS; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGUSERSDRIVERS" (
    "ID" integer NOT NULL,
    "ID_USER" integer NOT NULL,
    "CNPJ" text NOT NULL,
    "BIRTHDAY" date NOT NULL,
    "DRIVER_LICENSE_NUMBER" text NOT NULL,
    "DRIVER_LICENSE_TYPE" integer NOT NULL,
    "DRIVER_LICENSE_IMAGE" text,
    "REGISTER_DATE" timestamp without time zone NOT NULL
);


ALTER TABLE public."REGUSERSDRIVERS" OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 16472)
-- Name: REGUSERSDRIVERSTICKET; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGUSERSDRIVERSTICKET" (
    "ID" integer NOT NULL,
    "ID_USER" integer NOT NULL,
    "ID_PLAN" integer NOT NULL,
    "PLAN_START_DATE" date NOT NULL,
    "PLAN_END_DATE" date NOT NULL,
    "EXPECTED_RETURN_DATE" date NOT NULL,
    "PLAN_PRICE" numeric(10,2) NOT NULL,
    "PLAN_TAX" numeric(10,2) NOT NULL,
    "TOTAL_AMOUNT" numeric(10,2) NOT NULL
);


ALTER TABLE public."REGUSERSDRIVERSTICKET" OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16471)
-- Name: REGUSERSDRIVERSTICKET_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGUSERSDRIVERSTICKET_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGUSERSDRIVERSTICKET_ID_seq" OWNER TO postgres;

--
-- TOC entry 4860 (class 0 OID 0)
-- Dependencies: 229
-- Name: REGUSERSDRIVERSTICKET_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGUSERSDRIVERSTICKET_ID_seq" OWNED BY public."REGUSERSDRIVERSTICKET"."ID";


--
-- TOC entry 221 (class 1259 OID 16426)
-- Name: REGUSERSDRIVERS_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGUSERSDRIVERS_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGUSERSDRIVERS_ID_seq" OWNER TO postgres;

--
-- TOC entry 4861 (class 0 OID 0)
-- Dependencies: 221
-- Name: REGUSERSDRIVERS_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGUSERSDRIVERS_ID_seq" OWNED BY public."REGUSERSDRIVERS"."ID";


--
-- TOC entry 216 (class 1259 OID 16400)
-- Name: REGUSERSPROFILES; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGUSERSPROFILES" (
    "ID" integer NOT NULL,
    "PROFILE" text NOT NULL,
    "ADMIN" boolean NOT NULL
);


ALTER TABLE public."REGUSERSPROFILES" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16399)
-- Name: REGUSERSPROFILES_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGUSERSPROFILES_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGUSERSPROFILES_ID_seq" OWNER TO postgres;

--
-- TOC entry 4862 (class 0 OID 0)
-- Dependencies: 215
-- Name: REGUSERSPROFILES_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGUSERSPROFILES_ID_seq" OWNED BY public."REGUSERSPROFILES"."ID";


--
-- TOC entry 217 (class 1259 OID 16408)
-- Name: REGUSERS_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGUSERS_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGUSERS_ID_seq" OWNER TO postgres;

--
-- TOC entry 4863 (class 0 OID 0)
-- Dependencies: 217
-- Name: REGUSERS_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGUSERS_ID_seq" OWNED BY public."REGUSERS"."ID";


--
-- TOC entry 226 (class 1259 OID 16454)
-- Name: REGVEHICLES; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGVEHICLES" (
    "ID" integer NOT NULL,
    "YEAR_VEHICLE" integer NOT NULL,
    "MODEL_VEHICLE" text NOT NULL,
    "PLATE_VEHICLE" text NOT NULL,
    "STATUS" integer NOT NULL
);


ALTER TABLE public."REGVEHICLES" OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16463)
-- Name: REGVEHICLESSTATUS; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."REGVEHICLESSTATUS" (
    "ID" integer NOT NULL,
    "VEHICLE_STATUS" text NOT NULL,
    "AVAILABLE" boolean NOT NULL
);


ALTER TABLE public."REGVEHICLESSTATUS" OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16462)
-- Name: REGVEHICLESSTATUS_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGVEHICLESSTATUS_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGVEHICLESSTATUS_ID_seq" OWNER TO postgres;

--
-- TOC entry 4864 (class 0 OID 0)
-- Dependencies: 227
-- Name: REGVEHICLESSTATUS_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGVEHICLESSTATUS_ID_seq" OWNED BY public."REGVEHICLESSTATUS"."ID";


--
-- TOC entry 225 (class 1259 OID 16453)
-- Name: REGVEHICLES_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."REGVEHICLES_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."REGVEHICLES_ID_seq" OWNER TO postgres;

--
-- TOC entry 4865 (class 0 OID 0)
-- Dependencies: 225
-- Name: REGVEHICLES_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."REGVEHICLES_ID_seq" OWNED BY public."REGVEHICLES"."ID";


--
-- TOC entry 4671 (class 2604 OID 16421)
-- Name: REGDRIVERLICENSETYPE ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGDRIVERLICENSETYPE" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGDRIVERLICENSETYPE_ID_seq"'::regclass);


--
-- TOC entry 4673 (class 2604 OID 16448)
-- Name: REGPLANPRICES ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGPLANPRICES" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGPLANPRICES_ID_seq"'::regclass);


--
-- TOC entry 4670 (class 2604 OID 16412)
-- Name: REGUSERS ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERS" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGUSERS_ID_seq"'::regclass);


--
-- TOC entry 4672 (class 2604 OID 16430)
-- Name: REGUSERSDRIVERS ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERSDRIVERS" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGUSERSDRIVERS_ID_seq"'::regclass);


--
-- TOC entry 4675 (class 2604 OID 16475)
-- Name: REGUSERSDRIVERSTICKET ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERSDRIVERSTICKET" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGUSERSDRIVERSTICKET_ID_seq"'::regclass);


--
-- TOC entry 4669 (class 2604 OID 16403)
-- Name: REGUSERSPROFILES ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERSPROFILES" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGUSERSPROFILES_ID_seq"'::regclass);


--
-- TOC entry 4674 (class 2604 OID 16466)
-- Name: REGVEHICLESSTATUS ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGVEHICLESSTATUS" ALTER COLUMN "ID" SET DEFAULT nextval('public."REGVEHICLESSTATUS_ID_seq"'::regclass);


--
-- TOC entry 4840 (class 0 OID 16418)
-- Dependencies: 220
-- Data for Name: REGDRIVERLICENSETYPE; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGDRIVERLICENSETYPE" VALUES (1, 'A', true);
INSERT INTO public."REGDRIVERLICENSETYPE" VALUES (2, 'B', false);
INSERT INTO public."REGDRIVERLICENSETYPE" VALUES (3, 'A+B', false);


--
-- TOC entry 4844 (class 0 OID 16445)
-- Dependencies: 224
-- Data for Name: REGPLANPRICES; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGPLANPRICES" VALUES (1, '7 DIAS', 7, 30.00);
INSERT INTO public."REGPLANPRICES" VALUES (2, '15 DIAS', 15, 28.00);
INSERT INTO public."REGPLANPRICES" VALUES (3, '30 DIAS', 30, 22.00);
INSERT INTO public."REGPLANPRICES" VALUES (4, '45 DIAS', 45, 20.00);
INSERT INTO public."REGPLANPRICES" VALUES (5, '50 DIAS', 50, 18.00);


--
-- TOC entry 4838 (class 0 OID 16409)
-- Dependencies: 218
-- Data for Name: REGUSERS; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGUSERS" VALUES (6, '42319829000100', 'Antonio Silva', '$2a$11$.JplBivzqzQU/R3IFLcGYOWL1Q647hyK7tYMY4aJimtcNqbVLJR4a', 2);
INSERT INTO public."REGUSERS" VALUES (7, '42319829000101', 'João Carneiro', '$2a$11$XyWwnGHZcW8V0tl4jvOAYOkcaiuuzR98JnWH4fVPjYGYaoFhN.7pq', 2);
INSERT INTO public."REGUSERS" VALUES (8, '42319829000102', 'Fabio Mattos', '$2a$11$hDr8/tbcUx9t8YR6frMS1O2qGdqK2FociW/eSWK24aJSCStz2HlBa', 2);
INSERT INTO public."REGUSERS" VALUES (9, '42319829000103', 'Joaquim Silveira', '$2a$11$1QOICwzlgs7xRLbBd.UDfuOZEQCzYUzK57xQxabromO3rOjPTUGgK', 2);
INSERT INTO public."REGUSERS" VALUES (10, '42319829000110', 'Thiago Freitas', '$2a$11$rTCXMIhxst4/RQj1TuyoY.qkqjqkaCh4yTc6HVB/hDFb7NhuY9Ir2', 2);
INSERT INTO public."REGUSERS" VALUES (11, '42319829000112', 'Vander Carlos Soares', '$2a$11$V7rST6BwECE1TYOUbNJUReW1TikUzNqSsOzxs/6Bwy2zXK3edRTtS', 2);
INSERT INTO public."REGUSERS" VALUES (12, '42319829000133', 'Mariana Rodrigues', '$2a$11$NxykGwEvhKbpvKJ8U2jgfelKz7d0.Z1jCuq/cIqFRb4CwO8dOhKES', 2);
INSERT INTO public."REGUSERS" VALUES (1, 'sysadmin', 'Administrator', '$2a$11$aK2dBSqFVUWqxe92Bbij7OR.tmRc/gcxZuZA/0N2G6o4KHrvO.COO', 1);
INSERT INTO public."REGUSERS" VALUES (13, '42319829000142', 'MATHEUS NUNES', '$2a$11$8YRzqowLN2gNK2JsKuJkxuSxSc7z6Frq.7PFI.kjm9.WNOewoGVfq', 2);
INSERT INTO public."REGUSERS" VALUES (14, '42319829000155', 'JUAREZ GONÇALVES', '$2a$11$1QtsKHe4p7qhlAcRywtR4eIWlifSBh3I7x.7/QBYroU0uNtNJmGUW', 2);
INSERT INTO public."REGUSERS" VALUES (15, '52319829000103', 'Vinicius Farias', '$2a$11$FiEn1M9EDzL5iVrIL0zfPuL.rZx6qoP0kX4yJSmn6ngI.yR5UAeyq', 2);


--
-- TOC entry 4842 (class 0 OID 16427)
-- Dependencies: 222
-- Data for Name: REGUSERSDRIVERS; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGUSERSDRIVERS" VALUES (3, 6, '42319829000100', '1990-07-03', '01234567890', 0, 'C:\Projetos\Filipe\Rent Motorcycles Management\Resources\Software_Logo.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (4, 7, '42319829000101', '1985-07-03', '01234567888', 0, 'C:\Controle\Canada.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (5, 8, '42319829000102', '1992-07-03', '01234567778', 0, 'C:\Controle\Noruega.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (6, 9, '42319829000103', '1984-07-03', '01234566621', 0, 'C:\Controle\Noruega.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (7, 10, '42319829000110', '1999-07-03', '01234565432', 0, 'C:\Controle\Cachoeira Havasu, Arizona.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (8, 11, '42319829000112', '1966-06-03', '01234512345', 0, 'C:\Controle\Canada.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (9, 12, '42319829000133', '2004-07-03', '1231234567', 0, 'C:\Projetos\Filipe\Rent Motorcycles Management\Resources\Software_Logo_256_128_px.png', '2024-07-03 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (10, 13, '42319829000142', '2001-07-04', '1234432166', 0, 'C:\Controle\Valor Bem Investido\Bola de neve financeira.png', '2024-07-04 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (11, 14, '42319829000155', '2000-07-23', '1232143213', 0, 'C:\Controle\Cachoeira Havasu, Arizona.png', '2024-07-04 00:00:00');
INSERT INTO public."REGUSERSDRIVERS" VALUES (12, 15, '52319829000103', '2003-06-30', '9876544567', 0, 'C:\Controle\Leão.png', '2024-07-04 00:00:00');


--
-- TOC entry 4850 (class 0 OID 16472)
-- Dependencies: 230
-- Data for Name: REGUSERSDRIVERSTICKET; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGUSERSDRIVERSTICKET" VALUES (1, 7, 2, '2024-07-04', '2024-07-19', '2024-07-22', 420.00, 150.00, 570.00);
INSERT INTO public."REGUSERSDRIVERSTICKET" VALUES (2, 8, 1, '2024-07-04', '2024-07-11', '2024-07-08', 210.00, 18.00, 228.00);
INSERT INTO public."REGUSERSDRIVERSTICKET" VALUES (3, 14, 2, '2024-07-05', '2024-07-20', '2024-07-24', 420.00, 200.00, 620.00);
INSERT INTO public."REGUSERSDRIVERSTICKET" VALUES (4, 15, 2, '2024-07-05', '2024-07-20', '2024-07-17', 420.00, 33.60, 453.60);


--
-- TOC entry 4836 (class 0 OID 16400)
-- Dependencies: 216
-- Data for Name: REGUSERSPROFILES; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGUSERSPROFILES" VALUES (1, 'ADMIN', true);
INSERT INTO public."REGUSERSPROFILES" VALUES (2, 'MOTOCICLISTA', false);


--
-- TOC entry 4846 (class 0 OID 16454)
-- Dependencies: 226
-- Data for Name: REGVEHICLES; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGVEHICLES" VALUES (1, 2024, 'ZTX-14', 'YYY9876', 1);
INSERT INTO public."REGVEHICLES" VALUES (2, 2024, 'ZTX-14', 'ZZZ9871', 3);
INSERT INTO public."REGVEHICLES" VALUES (3, 2021, 'CB300', 'DHY4390', 2);
INSERT INTO public."REGVEHICLES" VALUES (10, 2024, 'FAZER-250', 'FTX8F90', 1);


--
-- TOC entry 4848 (class 0 OID 16463)
-- Dependencies: 228
-- Data for Name: REGVEHICLESSTATUS; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."REGVEHICLESSTATUS" VALUES (1, 'Disponível', true);
INSERT INTO public."REGVEHICLESSTATUS" VALUES (2, 'Em Uso', false);
INSERT INTO public."REGVEHICLESSTATUS" VALUES (3, 'Em Manutenção', false);


--
-- TOC entry 4866 (class 0 OID 0)
-- Dependencies: 219
-- Name: REGDRIVERLICENSETYPE_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGDRIVERLICENSETYPE_ID_seq"', 1, false);


--
-- TOC entry 4867 (class 0 OID 0)
-- Dependencies: 223
-- Name: REGPLANPRICES_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGPLANPRICES_ID_seq"', 1, false);


--
-- TOC entry 4868 (class 0 OID 0)
-- Dependencies: 229
-- Name: REGUSERSDRIVERSTICKET_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGUSERSDRIVERSTICKET_ID_seq"', 4, true);


--
-- TOC entry 4869 (class 0 OID 0)
-- Dependencies: 221
-- Name: REGUSERSDRIVERS_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGUSERSDRIVERS_ID_seq"', 12, true);


--
-- TOC entry 4870 (class 0 OID 0)
-- Dependencies: 215
-- Name: REGUSERSPROFILES_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGUSERSPROFILES_ID_seq"', 1, false);


--
-- TOC entry 4871 (class 0 OID 0)
-- Dependencies: 217
-- Name: REGUSERS_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGUSERS_ID_seq"', 15, true);


--
-- TOC entry 4872 (class 0 OID 0)
-- Dependencies: 227
-- Name: REGVEHICLESSTATUS_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGVEHICLESSTATUS_ID_seq"', 1, false);


--
-- TOC entry 4873 (class 0 OID 0)
-- Dependencies: 225
-- Name: REGVEHICLES_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."REGVEHICLES_ID_seq"', 1, false);


--
-- TOC entry 4681 (class 2606 OID 16425)
-- Name: REGDRIVERLICENSETYPE REGDRIVERLICENSETYPE_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGDRIVERLICENSETYPE"
    ADD CONSTRAINT "REGDRIVERLICENSETYPE_pkey" PRIMARY KEY ("DRIVER_LICENSE_TYPE");


--
-- TOC entry 4685 (class 2606 OID 16452)
-- Name: REGPLANPRICES REGPLANPRICES_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGPLANPRICES"
    ADD CONSTRAINT "REGPLANPRICES_pkey" PRIMARY KEY ("TOTAL_DAYS");


--
-- TOC entry 4691 (class 2606 OID 16479)
-- Name: REGUSERSDRIVERSTICKET REGUSERSDRIVERSTICKET_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERSDRIVERSTICKET"
    ADD CONSTRAINT "REGUSERSDRIVERSTICKET_pkey" PRIMARY KEY ("ID_USER");


--
-- TOC entry 4683 (class 2606 OID 16434)
-- Name: REGUSERSDRIVERS REGUSERSDRIVERS_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERSDRIVERS"
    ADD CONSTRAINT "REGUSERSDRIVERS_pkey" PRIMARY KEY ("CNPJ");


--
-- TOC entry 4677 (class 2606 OID 16407)
-- Name: REGUSERSPROFILES REGUSERSPROFILES_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERSPROFILES"
    ADD CONSTRAINT "REGUSERSPROFILES_pkey" PRIMARY KEY ("PROFILE");


--
-- TOC entry 4679 (class 2606 OID 16416)
-- Name: REGUSERS REGUSERS_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGUSERS"
    ADD CONSTRAINT "REGUSERS_pkey" PRIMARY KEY ("USER");


--
-- TOC entry 4689 (class 2606 OID 16470)
-- Name: REGVEHICLESSTATUS REGVEHICLESSTATUS_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGVEHICLESSTATUS"
    ADD CONSTRAINT "REGVEHICLESSTATUS_pkey" PRIMARY KEY ("VEHICLE_STATUS");


--
-- TOC entry 4687 (class 2606 OID 16461)
-- Name: REGVEHICLES REGVEHICLES_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."REGVEHICLES"
    ADD CONSTRAINT "REGVEHICLES_pkey" PRIMARY KEY ("PLATE_VEHICLE");


-- Completed on 2024-07-04 12:17:17

--
-- PostgreSQL database dump complete
--

