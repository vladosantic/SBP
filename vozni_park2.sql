PGDMP     3    "                {           vozni_park2    15.2    15.2 V    `           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            a           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            b           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            c           1262    24601    vozni_park2    DATABASE     �   CREATE DATABASE vozni_park2 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Croatian_Croatia.1252';
    DROP DATABASE vozni_park2;
                postgres    false            �            1259    24666    Dodjela_vozila    TABLE     �   CREATE TABLE public."Dodjela_vozila" (
    id integer NOT NULL,
    id_uposlenika integer,
    id_vozila integer,
    dodjeljeno date NOT NULL,
    vratiti_do date NOT NULL,
    dodatak character varying(50) NOT NULL
);
 $   DROP TABLE public."Dodjela_vozila";
       public         heap    postgres    false            �            1259    24665    Dodjela_vozila_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Dodjela_vozila_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."Dodjela_vozila_id_seq";
       public          postgres    false    233            d           0    0    Dodjela_vozila_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public."Dodjela_vozila_id_seq" OWNED BY public."Dodjela_vozila".id;
          public          postgres    false    232            �            1259    24652 
   Kategorija    TABLE     �   CREATE TABLE public."Kategorija" (
    id_kategorije integer NOT NULL,
    naziv_kategorije character varying(30) NOT NULL,
    opis_kategorije character varying(40) NOT NULL
);
     DROP TABLE public."Kategorija";
       public         heap    postgres    false            �            1259    24651    Kategorija_id_kategorije_seq    SEQUENCE     �   CREATE SEQUENCE public."Kategorija_id_kategorije_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public."Kategorija_id_kategorije_seq";
       public          postgres    false    229            e           0    0    Kategorija_id_kategorije_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public."Kategorija_id_kategorije_seq" OWNED BY public."Kategorija".id_kategorije;
          public          postgres    false    228            �            1259    24617    Marka    TABLE     c   CREATE TABLE public."Marka" (
    id integer NOT NULL,
    naziv character varying(30) NOT NULL
);
    DROP TABLE public."Marka";
       public         heap    postgres    false            �            1259    24616    Marka_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Marka_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public."Marka_id_seq";
       public          postgres    false    219            f           0    0    Marka_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."Marka_id_seq" OWNED BY public."Marka".id;
          public          postgres    false    218            �            1259    24624    Model_vozila    TABLE     �   CREATE TABLE public."Model_vozila" (
    id integer NOT NULL,
    naziv character varying(30) NOT NULL,
    id_marke integer
);
 "   DROP TABLE public."Model_vozila";
       public         heap    postgres    false            �            1259    24623    Model_vozila_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Model_vozila_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."Model_vozila_id_seq";
       public          postgres    false    221            g           0    0    Model_vozila_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public."Model_vozila_id_seq" OWNED BY public."Model_vozila".id;
          public          postgres    false    220            �            1259    24645    Pozicija    TABLE     o   CREATE TABLE public."Pozicija" (
    pozicija_id integer NOT NULL,
    naziv character varying(30) NOT NULL
);
    DROP TABLE public."Pozicija";
       public         heap    postgres    false            �            1259    24644    Pozicija_pozicija_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Pozicija_pozicija_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public."Pozicija_pozicija_id_seq";
       public          postgres    false    227            h           0    0    Pozicija_pozicija_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."Pozicija_pozicija_id_seq" OWNED BY public."Pozicija".pozicija_id;
          public          postgres    false    226            �            1259    24638 	   Uposlenik    TABLE     �  CREATE TABLE public."Uposlenik" (
    id_uposlenik integer NOT NULL,
    ime character varying(30) NOT NULL,
    prezime character varying(30) NOT NULL,
    pozicija_id integer,
    adresa character varying(30) NOT NULL,
    broj_mobitela character varying(30) NOT NULL,
    jmbg character varying(15) NOT NULL,
    email character varying(30) NOT NULL,
    datum_rodjenja date NOT NULL
);
    DROP TABLE public."Uposlenik";
       public         heap    postgres    false            �            1259    24637    Uposlenik_id_uposlenik_seq    SEQUENCE     �   CREATE SEQUENCE public."Uposlenik_id_uposlenik_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE public."Uposlenik_id_uposlenik_seq";
       public          postgres    false    225            i           0    0    Uposlenik_id_uposlenik_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Uposlenik_id_uposlenik_seq" OWNED BY public."Uposlenik".id_uposlenik;
          public          postgres    false    224            �            1259    24659    Uposlenik_kategorija    TABLE     }   CREATE TABLE public."Uposlenik_kategorija" (
    id integer NOT NULL,
    id_uposlenik integer,
    id_kategorije integer
);
 *   DROP TABLE public."Uposlenik_kategorija";
       public         heap    postgres    false            �            1259    24658    Uposlenik_kategorija_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Uposlenik_kategorija_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 4   DROP SEQUENCE public."Uposlenik_kategorija_id_seq";
       public          postgres    false    231            j           0    0    Uposlenik_kategorija_id_seq    SEQUENCE OWNED BY     _   ALTER SEQUENCE public."Uposlenik_kategorija_id_seq" OWNED BY public."Uposlenik_kategorija".id;
          public          postgres    false    230            �            1259    24603    Vozilo    TABLE     W  CREATE TABLE public."Vozilo" (
    id_vozila integer NOT NULL,
    model_vozila integer,
    broj_sasije character varying(20),
    registracijska_oznaka character varying(20),
    godina_proizvodnje integer NOT NULL,
    vrsta_vozila integer,
    id_lokacije integer,
    gorivo character varying(20),
    kategorija character varying(20)
);
    DROP TABLE public."Vozilo";
       public         heap    postgres    false            �            1259    24602    Vozilo_id_vozila_seq    SEQUENCE     �   CREATE SEQUENCE public."Vozilo_id_vozila_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public."Vozilo_id_vozila_seq";
       public          postgres    false    215            k           0    0    Vozilo_id_vozila_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."Vozilo_id_vozila_seq" OWNED BY public."Vozilo".id_vozila;
          public          postgres    false    214            �            1259    24610    Vrsta_vozila    TABLE     p   CREATE TABLE public."Vrsta_vozila" (
    vrsta_id integer NOT NULL,
    naziv character varying(30) NOT NULL
);
 "   DROP TABLE public."Vrsta_vozila";
       public         heap    postgres    false            �            1259    24609    Vrsta_vozila_vrsta_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Vrsta_vozila_vrsta_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Vrsta_vozila_vrsta_id_seq";
       public          postgres    false    217            l           0    0    Vrsta_vozila_vrsta_id_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public."Vrsta_vozila_vrsta_id_seq" OWNED BY public."Vrsta_vozila".vrsta_id;
          public          postgres    false    216            �            1259    24631    lokacija_vozila    TABLE     t   CREATE TABLE public.lokacija_vozila (
    id integer NOT NULL,
    naziv_lokacije character varying(30) NOT NULL
);
 #   DROP TABLE public.lokacija_vozila;
       public         heap    postgres    false            �            1259    24630    lokacija_vozila_id_seq    SEQUENCE     �   CREATE SEQUENCE public.lokacija_vozila_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.lokacija_vozila_id_seq;
       public          postgres    false    223            m           0    0    lokacija_vozila_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.lokacija_vozila_id_seq OWNED BY public.lokacija_vozila.id;
          public          postgres    false    222            �           2604    24669    Dodjela_vozila id    DEFAULT     z   ALTER TABLE ONLY public."Dodjela_vozila" ALTER COLUMN id SET DEFAULT nextval('public."Dodjela_vozila_id_seq"'::regclass);
 B   ALTER TABLE public."Dodjela_vozila" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    233    232    233            �           2604    24655    Kategorija id_kategorije    DEFAULT     �   ALTER TABLE ONLY public."Kategorija" ALTER COLUMN id_kategorije SET DEFAULT nextval('public."Kategorija_id_kategorije_seq"'::regclass);
 I   ALTER TABLE public."Kategorija" ALTER COLUMN id_kategorije DROP DEFAULT;
       public          postgres    false    228    229    229            �           2604    24620    Marka id    DEFAULT     h   ALTER TABLE ONLY public."Marka" ALTER COLUMN id SET DEFAULT nextval('public."Marka_id_seq"'::regclass);
 9   ALTER TABLE public."Marka" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    219    218    219            �           2604    24627    Model_vozila id    DEFAULT     v   ALTER TABLE ONLY public."Model_vozila" ALTER COLUMN id SET DEFAULT nextval('public."Model_vozila_id_seq"'::regclass);
 @   ALTER TABLE public."Model_vozila" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    221    221            �           2604    24648    Pozicija pozicija_id    DEFAULT     �   ALTER TABLE ONLY public."Pozicija" ALTER COLUMN pozicija_id SET DEFAULT nextval('public."Pozicija_pozicija_id_seq"'::regclass);
 E   ALTER TABLE public."Pozicija" ALTER COLUMN pozicija_id DROP DEFAULT;
       public          postgres    false    226    227    227            �           2604    24641    Uposlenik id_uposlenik    DEFAULT     �   ALTER TABLE ONLY public."Uposlenik" ALTER COLUMN id_uposlenik SET DEFAULT nextval('public."Uposlenik_id_uposlenik_seq"'::regclass);
 G   ALTER TABLE public."Uposlenik" ALTER COLUMN id_uposlenik DROP DEFAULT;
       public          postgres    false    224    225    225            �           2604    24662    Uposlenik_kategorija id    DEFAULT     �   ALTER TABLE ONLY public."Uposlenik_kategorija" ALTER COLUMN id SET DEFAULT nextval('public."Uposlenik_kategorija_id_seq"'::regclass);
 H   ALTER TABLE public."Uposlenik_kategorija" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    231    230    231            �           2604    24606    Vozilo id_vozila    DEFAULT     x   ALTER TABLE ONLY public."Vozilo" ALTER COLUMN id_vozila SET DEFAULT nextval('public."Vozilo_id_vozila_seq"'::regclass);
 A   ALTER TABLE public."Vozilo" ALTER COLUMN id_vozila DROP DEFAULT;
       public          postgres    false    215    214    215            �           2604    24613    Vrsta_vozila vrsta_id    DEFAULT     �   ALTER TABLE ONLY public."Vrsta_vozila" ALTER COLUMN vrsta_id SET DEFAULT nextval('public."Vrsta_vozila_vrsta_id_seq"'::regclass);
 F   ALTER TABLE public."Vrsta_vozila" ALTER COLUMN vrsta_id DROP DEFAULT;
       public          postgres    false    217    216    217            �           2604    24634    lokacija_vozila id    DEFAULT     x   ALTER TABLE ONLY public.lokacija_vozila ALTER COLUMN id SET DEFAULT nextval('public.lokacija_vozila_id_seq'::regclass);
 A   ALTER TABLE public.lokacija_vozila ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    222    223    223            ]          0    24666    Dodjela_vozila 
   TABLE DATA           i   COPY public."Dodjela_vozila" (id, id_uposlenika, id_vozila, dodjeljeno, vratiti_do, dodatak) FROM stdin;
    public          postgres    false    233   �g       Y          0    24652 
   Kategorija 
   TABLE DATA           X   COPY public."Kategorija" (id_kategorije, naziv_kategorije, opis_kategorije) FROM stdin;
    public          postgres    false    229   <h       O          0    24617    Marka 
   TABLE DATA           ,   COPY public."Marka" (id, naziv) FROM stdin;
    public          postgres    false    219   i       Q          0    24624    Model_vozila 
   TABLE DATA           =   COPY public."Model_vozila" (id, naziv, id_marke) FROM stdin;
    public          postgres    false    221   �i       W          0    24645    Pozicija 
   TABLE DATA           8   COPY public."Pozicija" (pozicija_id, naziv) FROM stdin;
    public          postgres    false    227   �i       U          0    24638 	   Uposlenik 
   TABLE DATA           �   COPY public."Uposlenik" (id_uposlenik, ime, prezime, pozicija_id, adresa, broj_mobitela, jmbg, email, datum_rodjenja) FROM stdin;
    public          postgres    false    225   �j       [          0    24659    Uposlenik_kategorija 
   TABLE DATA           Q   COPY public."Uposlenik_kategorija" (id, id_uposlenik, id_kategorije) FROM stdin;
    public          postgres    false    231   �k       K          0    24603    Vozilo 
   TABLE DATA           �   COPY public."Vozilo" (id_vozila, model_vozila, broj_sasije, registracijska_oznaka, godina_proizvodnje, vrsta_vozila, id_lokacije, gorivo, kategorija) FROM stdin;
    public          postgres    false    215   �k       M          0    24610    Vrsta_vozila 
   TABLE DATA           9   COPY public."Vrsta_vozila" (vrsta_id, naziv) FROM stdin;
    public          postgres    false    217   �l       S          0    24631    lokacija_vozila 
   TABLE DATA           =   COPY public.lokacija_vozila (id, naziv_lokacije) FROM stdin;
    public          postgres    false    223   Jm       n           0    0    Dodjela_vozila_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."Dodjela_vozila_id_seq"', 3, true);
          public          postgres    false    232            o           0    0    Kategorija_id_kategorije_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public."Kategorija_id_kategorije_seq"', 14, true);
          public          postgres    false    228            p           0    0    Marka_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Marka_id_seq"', 13, true);
          public          postgres    false    218            q           0    0    Model_vozila_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Model_vozila_id_seq"', 10, true);
          public          postgres    false    220            r           0    0    Pozicija_pozicija_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public."Pozicija_pozicija_id_seq"', 13, true);
          public          postgres    false    226            s           0    0    Uposlenik_id_uposlenik_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Uposlenik_id_uposlenik_seq"', 2, true);
          public          postgres    false    224            t           0    0    Uposlenik_kategorija_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public."Uposlenik_kategorija_id_seq"', 12, true);
          public          postgres    false    230            u           0    0    Vozilo_id_vozila_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."Vozilo_id_vozila_seq"', 14, true);
          public          postgres    false    214            v           0    0    Vrsta_vozila_vrsta_id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Vrsta_vozila_vrsta_id_seq"', 12, true);
          public          postgres    false    216            w           0    0    lokacija_vozila_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.lokacija_vozila_id_seq', 12, true);
          public          postgres    false    222            �           2606    24671     Dodjela_vozila pk_Dodjela_vozila 
   CONSTRAINT     b   ALTER TABLE ONLY public."Dodjela_vozila"
    ADD CONSTRAINT "pk_Dodjela_vozila" PRIMARY KEY (id);
 N   ALTER TABLE ONLY public."Dodjela_vozila" DROP CONSTRAINT "pk_Dodjela_vozila";
       public            postgres    false    233            �           2606    24657    Kategorija pk_Kategorija 
   CONSTRAINT     e   ALTER TABLE ONLY public."Kategorija"
    ADD CONSTRAINT "pk_Kategorija" PRIMARY KEY (id_kategorije);
 F   ALTER TABLE ONLY public."Kategorija" DROP CONSTRAINT "pk_Kategorija";
       public            postgres    false    229            �           2606    24622    Marka pk_Marka 
   CONSTRAINT     P   ALTER TABLE ONLY public."Marka"
    ADD CONSTRAINT "pk_Marka" PRIMARY KEY (id);
 <   ALTER TABLE ONLY public."Marka" DROP CONSTRAINT "pk_Marka";
       public            postgres    false    219            �           2606    24629    Model_vozila pk_Model_vozila 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Model_vozila"
    ADD CONSTRAINT "pk_Model_vozila" PRIMARY KEY (id);
 J   ALTER TABLE ONLY public."Model_vozila" DROP CONSTRAINT "pk_Model_vozila";
       public            postgres    false    221            �           2606    24650    Pozicija pk_Pozicija 
   CONSTRAINT     _   ALTER TABLE ONLY public."Pozicija"
    ADD CONSTRAINT "pk_Pozicija" PRIMARY KEY (pozicija_id);
 B   ALTER TABLE ONLY public."Pozicija" DROP CONSTRAINT "pk_Pozicija";
       public            postgres    false    227            �           2606    24643    Uposlenik pk_Uposlenik 
   CONSTRAINT     b   ALTER TABLE ONLY public."Uposlenik"
    ADD CONSTRAINT "pk_Uposlenik" PRIMARY KEY (id_uposlenik);
 D   ALTER TABLE ONLY public."Uposlenik" DROP CONSTRAINT "pk_Uposlenik";
       public            postgres    false    225            �           2606    24664 ,   Uposlenik_kategorija pk_Uposlenik_kategorija 
   CONSTRAINT     n   ALTER TABLE ONLY public."Uposlenik_kategorija"
    ADD CONSTRAINT "pk_Uposlenik_kategorija" PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public."Uposlenik_kategorija" DROP CONSTRAINT "pk_Uposlenik_kategorija";
       public            postgres    false    231            �           2606    24608    Vozilo pk_Vozilo 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT "pk_Vozilo" PRIMARY KEY (id_vozila);
 >   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT "pk_Vozilo";
       public            postgres    false    215            �           2606    24615    Vrsta_vozila pk_Vrsta_vozila 
   CONSTRAINT     d   ALTER TABLE ONLY public."Vrsta_vozila"
    ADD CONSTRAINT "pk_Vrsta_vozila" PRIMARY KEY (vrsta_id);
 J   ALTER TABLE ONLY public."Vrsta_vozila" DROP CONSTRAINT "pk_Vrsta_vozila";
       public            postgres    false    217            �           2606    24636 "   lokacija_vozila pk_lokacija_vozila 
   CONSTRAINT     `   ALTER TABLE ONLY public.lokacija_vozila
    ADD CONSTRAINT pk_lokacija_vozila PRIMARY KEY (id);
 L   ALTER TABLE ONLY public.lokacija_vozila DROP CONSTRAINT pk_lokacija_vozila;
       public            postgres    false    223            �           1259    24734    fki_fk_Vozilo_id_lokacije    INDEX     W   CREATE INDEX "fki_fk_Vozilo_id_lokacije" ON public."Vozilo" USING btree (id_lokacije);
 /   DROP INDEX public."fki_fk_Vozilo_id_lokacije";
       public            postgres    false    215            �           1259    24728    fki_fk_Vozilo_model_vozila    INDEX     Y   CREATE INDEX "fki_fk_Vozilo_model_vozila" ON public."Vozilo" USING btree (model_vozila);
 0   DROP INDEX public."fki_fk_Vozilo_model_vozila";
       public            postgres    false    215            �           1259    24722    fki_fk_Vozilo_vrsta_vozila    INDEX     Y   CREATE INDEX "fki_fk_Vozilo_vrsta_vozila" ON public."Vozilo" USING btree (vrsta_vozila);
 0   DROP INDEX public."fki_fk_Vozilo_vrsta_vozila";
       public            postgres    false    215            �           2606    24868 .   Dodjela_vozila fk_dodjela_vozila_id_uposlenika    FK CONSTRAINT     �   ALTER TABLE ONLY public."Dodjela_vozila"
    ADD CONSTRAINT fk_dodjela_vozila_id_uposlenika FOREIGN KEY (id_uposlenika) REFERENCES public."Uposlenik"(id_uposlenik) ON DELETE CASCADE;
 Z   ALTER TABLE ONLY public."Dodjela_vozila" DROP CONSTRAINT fk_dodjela_vozila_id_uposlenika;
       public          postgres    false    3242    233    225            �           2606    24873 *   Dodjela_vozila fk_dodjela_vozila_id_vozila    FK CONSTRAINT     �   ALTER TABLE ONLY public."Dodjela_vozila"
    ADD CONSTRAINT fk_dodjela_vozila_id_vozila FOREIGN KEY (id_vozila) REFERENCES public."Vozilo"(id_vozila) ON DELETE CASCADE;
 V   ALTER TABLE ONLY public."Dodjela_vozila" DROP CONSTRAINT fk_dodjela_vozila_id_vozila;
       public          postgres    false    3232    233    215            �           2606    24848 %   Model_vozila fk_model_vozila_id_marke    FK CONSTRAINT     �   ALTER TABLE ONLY public."Model_vozila"
    ADD CONSTRAINT fk_model_vozila_id_marke FOREIGN KEY (id_marke) REFERENCES public."Marka"(id) ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public."Model_vozila" DROP CONSTRAINT fk_model_vozila_id_marke;
       public          postgres    false    221    219    3236            �           2606    24853 :   Uposlenik_kategorija fk_uposlenik_kategorija_id_kategorije    FK CONSTRAINT     �   ALTER TABLE ONLY public."Uposlenik_kategorija"
    ADD CONSTRAINT fk_uposlenik_kategorija_id_kategorije FOREIGN KEY (id_kategorije) REFERENCES public."Kategorija"(id_kategorije) ON DELETE CASCADE;
 f   ALTER TABLE ONLY public."Uposlenik_kategorija" DROP CONSTRAINT fk_uposlenik_kategorija_id_kategorije;
       public          postgres    false    229    231    3246            �           2606    24858 9   Uposlenik_kategorija fk_uposlenik_kategorija_id_uposlenik    FK CONSTRAINT     �   ALTER TABLE ONLY public."Uposlenik_kategorija"
    ADD CONSTRAINT fk_uposlenik_kategorija_id_uposlenik FOREIGN KEY (id_uposlenik) REFERENCES public."Uposlenik"(id_uposlenik) ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."Uposlenik_kategorija" DROP CONSTRAINT fk_uposlenik_kategorija_id_uposlenik;
       public          postgres    false    225    3242    231            �           2606    24863 "   Uposlenik fk_uposlenik_pozicija_id    FK CONSTRAINT     �   ALTER TABLE ONLY public."Uposlenik"
    ADD CONSTRAINT fk_uposlenik_pozicija_id FOREIGN KEY (pozicija_id) REFERENCES public."Pozicija"(pozicija_id) ON DELETE CASCADE;
 N   ALTER TABLE ONLY public."Uposlenik" DROP CONSTRAINT fk_uposlenik_pozicija_id;
       public          postgres    false    227    3244    225            �           2606    24843    Vozilo fk_vozilo_id_lokacije    FK CONSTRAINT     �   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT fk_vozilo_id_lokacije FOREIGN KEY (id_lokacije) REFERENCES public.lokacija_vozila(id) ON DELETE CASCADE;
 H   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT fk_vozilo_id_lokacije;
       public          postgres    false    223    3240    215            �           2606    24838    Vozilo fk_vozilo_model_vozila    FK CONSTRAINT     �   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT fk_vozilo_model_vozila FOREIGN KEY (model_vozila) REFERENCES public."Model_vozila"(id) ON DELETE CASCADE;
 I   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT fk_vozilo_model_vozila;
       public          postgres    false    221    3238    215            �           2606    24833    Vozilo fk_vozilo_vrsta_vozila    FK CONSTRAINT     �   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT fk_vozilo_vrsta_vozila FOREIGN KEY (vrsta_vozila) REFERENCES public."Vrsta_vozila"(vrsta_id) ON DELETE CASCADE;
 I   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT fk_vozilo_vrsta_vozila;
       public          postgres    false    215    217    3234            ]   ^   x�M�9�0k�+�@P'1��4)(9�_�l4�H;�2�K���XCJ���q_�~��QI����g�۲k�����mq�=�R,���e�m� ')�      Y   �   x�]�=
A���9� ��6��(��Mpɬ����b�`������]D����>,96����BIJ�|k_�A��L�-y��)���K]y��,oG0emc_�����e��`cQ�5N`ÏKV�,���j�T���6)�!+c�V�<���s���`�t~�nfz05���8�����f�ֱ�� ���_�      O   l   x���
�@�����dj�օ�D�6n�C"��a__g{Nh�;��=�i84�?,1�nQX�3�g�l}��,�Y����Q��5�AӢ����7��'�3�_���      Q   X   x��;
�0���SxE�Ѥ^��ڈD,,$���q��QZ-�2�^��3@�����_��`7}�p�f�۱2A�3ܜ�yN$�h      W   �   x�M��1D��*\!~! ����=sk����@/�/LF8�f�p�0(MNqW�e��C}n��(l��lL��=��D�]bLL:�"#y���N,�*J�LC�'	й�p-�-q���p���g�����p�7�      U   �   x�mнn�0����#,��u-R�.ݲX(�I)�"^!/��O𐋲!����h���O|d��������7M�֛��V���㏣��@��}ݖ�E?���oj�k�*C��5.��-�ap�`O3:bF��Z���q������-c��!rѐ��@��r��� �;�gXK�^�{�xq����a�n_8�3�0Xр����Zz����7͏̪�����mh@G �K�c܋�������      [   3   x�3�4�4�����1~\&@!.N�����ch��b���� �-�      K   �   x�e��N�@E�ٯ�/@�����o[�'�Ҙ(�E���ihG���1`��f�*oq��U�=4�$d-�
#c ���e��0��q����Ay���%ikd^lR���|�]ߠ]޿�;�R5�Yƌ��J���Y���+6���=�"@���ž>e�:V�9H�ld�EO�����{сU&��n�g-�`���cvV��fRdλ*��c��-c�FD"o�%F�}�����G�����<_^��A�j�Q�      M   k   x�3��N�����2�t,-�O*-�2�)J�.�/�2�t�L����2��.-I-�����M���t�I�.)�<қ���ԙ�����eh�\�_TR��"
6���� ơ&"      S   a   x�3���J�N�2��/��L9�S���8Js�,8]J�����2��,9����K���24��N,��/KL�2jI/JM�24���/.����� -��     