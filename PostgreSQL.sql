PGDMP     '    !                {           hrvoje    15.2    15.2 S    ]           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ^           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            _           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            `           1262    24878    hrvoje    DATABASE     |   CREATE DATABASE hrvoje WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Croatian_Croatia.1252';
    DROP DATABASE hrvoje;
                postgres    false            �            1259    24943    Dodjela_vozila    TABLE     �   CREATE TABLE public."Dodjela_vozila" (
    id integer NOT NULL,
    id_uposlenika integer,
    id_vozila integer,
    dodjeljeno date NOT NULL,
    vratiti_do date NOT NULL,
    dodatak character varying(50) NOT NULL
);
 $   DROP TABLE public."Dodjela_vozila";
       public         heap    postgres    false            �            1259    24942    Dodjela_vozila_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Dodjela_vozila_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."Dodjela_vozila_id_seq";
       public          postgres    false    233            a           0    0    Dodjela_vozila_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public."Dodjela_vozila_id_seq" OWNED BY public."Dodjela_vozila".id;
          public          postgres    false    232            �            1259    24929 
   Kategorija    TABLE     �   CREATE TABLE public."Kategorija" (
    id_kategorije integer NOT NULL,
    naziv_kategorije character varying(30) NOT NULL,
    opis_kategorije character varying(40) NOT NULL
);
     DROP TABLE public."Kategorija";
       public         heap    postgres    false            �            1259    24928    Kategorija_id_kategorije_seq    SEQUENCE     �   CREATE SEQUENCE public."Kategorija_id_kategorije_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public."Kategorija_id_kategorije_seq";
       public          postgres    false    229            b           0    0    Kategorija_id_kategorije_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public."Kategorija_id_kategorije_seq" OWNED BY public."Kategorija".id_kategorije;
          public          postgres    false    228            �            1259    24894    Marka    TABLE     c   CREATE TABLE public."Marka" (
    id integer NOT NULL,
    naziv character varying(30) NOT NULL
);
    DROP TABLE public."Marka";
       public         heap    postgres    false            �            1259    24893    Marka_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Marka_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public."Marka_id_seq";
       public          postgres    false    219            c           0    0    Marka_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."Marka_id_seq" OWNED BY public."Marka".id;
          public          postgres    false    218            �            1259    24901    Model_vozila    TABLE     �   CREATE TABLE public."Model_vozila" (
    id integer NOT NULL,
    naziv character varying(30) NOT NULL,
    id_marke integer
);
 "   DROP TABLE public."Model_vozila";
       public         heap    postgres    false            �            1259    24900    Model_vozila_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Model_vozila_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."Model_vozila_id_seq";
       public          postgres    false    221            d           0    0    Model_vozila_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public."Model_vozila_id_seq" OWNED BY public."Model_vozila".id;
          public          postgres    false    220            �            1259    24922    Pozicija    TABLE     o   CREATE TABLE public."Pozicija" (
    pozicija_id integer NOT NULL,
    naziv character varying(30) NOT NULL
);
    DROP TABLE public."Pozicija";
       public         heap    postgres    false            �            1259    24921    Pozicija_pozicija_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Pozicija_pozicija_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public."Pozicija_pozicija_id_seq";
       public          postgres    false    227            e           0    0    Pozicija_pozicija_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."Pozicija_pozicija_id_seq" OWNED BY public."Pozicija".pozicija_id;
          public          postgres    false    226            �            1259    24915 	   Uposlenik    TABLE     �  CREATE TABLE public."Uposlenik" (
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
       public         heap    postgres    false            �            1259    24914    Uposlenik_id_uposlenik_seq    SEQUENCE     �   CREATE SEQUENCE public."Uposlenik_id_uposlenik_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE public."Uposlenik_id_uposlenik_seq";
       public          postgres    false    225            f           0    0    Uposlenik_id_uposlenik_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Uposlenik_id_uposlenik_seq" OWNED BY public."Uposlenik".id_uposlenik;
          public          postgres    false    224            �            1259    24936    Uposlenik_kategorija    TABLE     }   CREATE TABLE public."Uposlenik_kategorija" (
    id integer NOT NULL,
    id_uposlenik integer,
    id_kategorije integer
);
 *   DROP TABLE public."Uposlenik_kategorija";
       public         heap    postgres    false            �            1259    24935    Uposlenik_kategorija_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Uposlenik_kategorija_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 4   DROP SEQUENCE public."Uposlenik_kategorija_id_seq";
       public          postgres    false    231            g           0    0    Uposlenik_kategorija_id_seq    SEQUENCE OWNED BY     _   ALTER SEQUENCE public."Uposlenik_kategorija_id_seq" OWNED BY public."Uposlenik_kategorija".id;
          public          postgres    false    230            �            1259    24880    Vozilo    TABLE     W  CREATE TABLE public."Vozilo" (
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
       public         heap    postgres    false            �            1259    24879    Vozilo_id_vozila_seq    SEQUENCE     �   CREATE SEQUENCE public."Vozilo_id_vozila_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public."Vozilo_id_vozila_seq";
       public          postgres    false    215            h           0    0    Vozilo_id_vozila_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."Vozilo_id_vozila_seq" OWNED BY public."Vozilo".id_vozila;
          public          postgres    false    214            �            1259    24887    Vrsta_vozila    TABLE     p   CREATE TABLE public."Vrsta_vozila" (
    vrsta_id integer NOT NULL,
    naziv character varying(30) NOT NULL
);
 "   DROP TABLE public."Vrsta_vozila";
       public         heap    postgres    false            �            1259    24886    Vrsta_vozila_vrsta_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Vrsta_vozila_vrsta_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Vrsta_vozila_vrsta_id_seq";
       public          postgres    false    217            i           0    0    Vrsta_vozila_vrsta_id_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public."Vrsta_vozila_vrsta_id_seq" OWNED BY public."Vrsta_vozila".vrsta_id;
          public          postgres    false    216            �            1259    24908    lokacija_vozila    TABLE     t   CREATE TABLE public.lokacija_vozila (
    id integer NOT NULL,
    naziv_lokacije character varying(30) NOT NULL
);
 #   DROP TABLE public.lokacija_vozila;
       public         heap    postgres    false            �            1259    24907    lokacija_vozila_id_seq    SEQUENCE     �   CREATE SEQUENCE public.lokacija_vozila_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.lokacija_vozila_id_seq;
       public          postgres    false    223            j           0    0    lokacija_vozila_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.lokacija_vozila_id_seq OWNED BY public.lokacija_vozila.id;
          public          postgres    false    222            �           2604    24946    Dodjela_vozila id    DEFAULT     z   ALTER TABLE ONLY public."Dodjela_vozila" ALTER COLUMN id SET DEFAULT nextval('public."Dodjela_vozila_id_seq"'::regclass);
 B   ALTER TABLE public."Dodjela_vozila" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    232    233    233            �           2604    24932    Kategorija id_kategorije    DEFAULT     �   ALTER TABLE ONLY public."Kategorija" ALTER COLUMN id_kategorije SET DEFAULT nextval('public."Kategorija_id_kategorije_seq"'::regclass);
 I   ALTER TABLE public."Kategorija" ALTER COLUMN id_kategorije DROP DEFAULT;
       public          postgres    false    228    229    229            �           2604    24897    Marka id    DEFAULT     h   ALTER TABLE ONLY public."Marka" ALTER COLUMN id SET DEFAULT nextval('public."Marka_id_seq"'::regclass);
 9   ALTER TABLE public."Marka" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    218    219    219            �           2604    24904    Model_vozila id    DEFAULT     v   ALTER TABLE ONLY public."Model_vozila" ALTER COLUMN id SET DEFAULT nextval('public."Model_vozila_id_seq"'::regclass);
 @   ALTER TABLE public."Model_vozila" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    221    221            �           2604    24925    Pozicija pozicija_id    DEFAULT     �   ALTER TABLE ONLY public."Pozicija" ALTER COLUMN pozicija_id SET DEFAULT nextval('public."Pozicija_pozicija_id_seq"'::regclass);
 E   ALTER TABLE public."Pozicija" ALTER COLUMN pozicija_id DROP DEFAULT;
       public          postgres    false    227    226    227            �           2604    24918    Uposlenik id_uposlenik    DEFAULT     �   ALTER TABLE ONLY public."Uposlenik" ALTER COLUMN id_uposlenik SET DEFAULT nextval('public."Uposlenik_id_uposlenik_seq"'::regclass);
 G   ALTER TABLE public."Uposlenik" ALTER COLUMN id_uposlenik DROP DEFAULT;
       public          postgres    false    225    224    225            �           2604    24939    Uposlenik_kategorija id    DEFAULT     �   ALTER TABLE ONLY public."Uposlenik_kategorija" ALTER COLUMN id SET DEFAULT nextval('public."Uposlenik_kategorija_id_seq"'::regclass);
 H   ALTER TABLE public."Uposlenik_kategorija" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    231    230    231            �           2604    24883    Vozilo id_vozila    DEFAULT     x   ALTER TABLE ONLY public."Vozilo" ALTER COLUMN id_vozila SET DEFAULT nextval('public."Vozilo_id_vozila_seq"'::regclass);
 A   ALTER TABLE public."Vozilo" ALTER COLUMN id_vozila DROP DEFAULT;
       public          postgres    false    214    215    215            �           2604    24890    Vrsta_vozila vrsta_id    DEFAULT     �   ALTER TABLE ONLY public."Vrsta_vozila" ALTER COLUMN vrsta_id SET DEFAULT nextval('public."Vrsta_vozila_vrsta_id_seq"'::regclass);
 F   ALTER TABLE public."Vrsta_vozila" ALTER COLUMN vrsta_id DROP DEFAULT;
       public          postgres    false    216    217    217            �           2604    24911    lokacija_vozila id    DEFAULT     x   ALTER TABLE ONLY public.lokacija_vozila ALTER COLUMN id SET DEFAULT nextval('public.lokacija_vozila_id_seq'::regclass);
 A   ALTER TABLE public.lokacija_vozila ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    222    223    223            Z          0    24943    Dodjela_vozila 
   TABLE DATA           i   COPY public."Dodjela_vozila" (id, id_uposlenika, id_vozila, dodjeljeno, vratiti_do, dodatak) FROM stdin;
    public          postgres    false    233   ud       V          0    24929 
   Kategorija 
   TABLE DATA           X   COPY public."Kategorija" (id_kategorije, naziv_kategorije, opis_kategorije) FROM stdin;
    public          postgres    false    229   e       L          0    24894    Marka 
   TABLE DATA           ,   COPY public."Marka" (id, naziv) FROM stdin;
    public          postgres    false    219   �e       N          0    24901    Model_vozila 
   TABLE DATA           =   COPY public."Model_vozila" (id, naziv, id_marke) FROM stdin;
    public          postgres    false    221   yf       T          0    24922    Pozicija 
   TABLE DATA           8   COPY public."Pozicija" (pozicija_id, naziv) FROM stdin;
    public          postgres    false    227   �f       R          0    24915 	   Uposlenik 
   TABLE DATA           �   COPY public."Uposlenik" (id_uposlenik, ime, prezime, pozicija_id, adresa, broj_mobitela, jmbg, email, datum_rodjenja) FROM stdin;
    public          postgres    false    225   �g       X          0    24936    Uposlenik_kategorija 
   TABLE DATA           Q   COPY public."Uposlenik_kategorija" (id, id_uposlenik, id_kategorije) FROM stdin;
    public          postgres    false    231   i       H          0    24880    Vozilo 
   TABLE DATA           �   COPY public."Vozilo" (id_vozila, model_vozila, broj_sasije, registracijska_oznaka, godina_proizvodnje, vrsta_vozila, id_lokacije, gorivo, kategorija) FROM stdin;
    public          postgres    false    215   Ki       J          0    24887    Vrsta_vozila 
   TABLE DATA           9   COPY public."Vrsta_vozila" (vrsta_id, naziv) FROM stdin;
    public          postgres    false    217   �j       P          0    24908    lokacija_vozila 
   TABLE DATA           =   COPY public.lokacija_vozila (id, naziv_lokacije) FROM stdin;
    public          postgres    false    223   @k       k           0    0    Dodjela_vozila_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."Dodjela_vozila_id_seq"', 1, false);
          public          postgres    false    232            l           0    0    Kategorija_id_kategorije_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public."Kategorija_id_kategorije_seq"', 1, false);
          public          postgres    false    228            m           0    0    Marka_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Marka_id_seq"', 1, false);
          public          postgres    false    218            n           0    0    Model_vozila_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Model_vozila_id_seq"', 1, false);
          public          postgres    false    220            o           0    0    Pozicija_pozicija_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public."Pozicija_pozicija_id_seq"', 1, false);
          public          postgres    false    226            p           0    0    Uposlenik_id_uposlenik_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public."Uposlenik_id_uposlenik_seq"', 1, false);
          public          postgres    false    224            q           0    0    Uposlenik_kategorija_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public."Uposlenik_kategorija_id_seq"', 1, false);
          public          postgres    false    230            r           0    0    Vozilo_id_vozila_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."Vozilo_id_vozila_seq"', 1, false);
          public          postgres    false    214            s           0    0    Vrsta_vozila_vrsta_id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Vrsta_vozila_vrsta_id_seq"', 1, false);
          public          postgres    false    216            t           0    0    lokacija_vozila_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.lokacija_vozila_id_seq', 1, false);
          public          postgres    false    222            �           2606    24948     Dodjela_vozila pk_Dodjela_vozila 
   CONSTRAINT     b   ALTER TABLE ONLY public."Dodjela_vozila"
    ADD CONSTRAINT "pk_Dodjela_vozila" PRIMARY KEY (id);
 N   ALTER TABLE ONLY public."Dodjela_vozila" DROP CONSTRAINT "pk_Dodjela_vozila";
       public            postgres    false    233            �           2606    24934    Kategorija pk_Kategorija 
   CONSTRAINT     e   ALTER TABLE ONLY public."Kategorija"
    ADD CONSTRAINT "pk_Kategorija" PRIMARY KEY (id_kategorije);
 F   ALTER TABLE ONLY public."Kategorija" DROP CONSTRAINT "pk_Kategorija";
       public            postgres    false    229            �           2606    24899    Marka pk_Marka 
   CONSTRAINT     P   ALTER TABLE ONLY public."Marka"
    ADD CONSTRAINT "pk_Marka" PRIMARY KEY (id);
 <   ALTER TABLE ONLY public."Marka" DROP CONSTRAINT "pk_Marka";
       public            postgres    false    219            �           2606    24906    Model_vozila pk_Model_vozila 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Model_vozila"
    ADD CONSTRAINT "pk_Model_vozila" PRIMARY KEY (id);
 J   ALTER TABLE ONLY public."Model_vozila" DROP CONSTRAINT "pk_Model_vozila";
       public            postgres    false    221            �           2606    24927    Pozicija pk_Pozicija 
   CONSTRAINT     _   ALTER TABLE ONLY public."Pozicija"
    ADD CONSTRAINT "pk_Pozicija" PRIMARY KEY (pozicija_id);
 B   ALTER TABLE ONLY public."Pozicija" DROP CONSTRAINT "pk_Pozicija";
       public            postgres    false    227            �           2606    24920    Uposlenik pk_Uposlenik 
   CONSTRAINT     b   ALTER TABLE ONLY public."Uposlenik"
    ADD CONSTRAINT "pk_Uposlenik" PRIMARY KEY (id_uposlenik);
 D   ALTER TABLE ONLY public."Uposlenik" DROP CONSTRAINT "pk_Uposlenik";
       public            postgres    false    225            �           2606    24941 ,   Uposlenik_kategorija pk_Uposlenik_kategorija 
   CONSTRAINT     n   ALTER TABLE ONLY public."Uposlenik_kategorija"
    ADD CONSTRAINT "pk_Uposlenik_kategorija" PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public."Uposlenik_kategorija" DROP CONSTRAINT "pk_Uposlenik_kategorija";
       public            postgres    false    231            �           2606    24885    Vozilo pk_Vozilo 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT "pk_Vozilo" PRIMARY KEY (id_vozila);
 >   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT "pk_Vozilo";
       public            postgres    false    215            �           2606    24892    Vrsta_vozila pk_Vrsta_vozila 
   CONSTRAINT     d   ALTER TABLE ONLY public."Vrsta_vozila"
    ADD CONSTRAINT "pk_Vrsta_vozila" PRIMARY KEY (vrsta_id);
 J   ALTER TABLE ONLY public."Vrsta_vozila" DROP CONSTRAINT "pk_Vrsta_vozila";
       public            postgres    false    217            �           2606    24913 "   lokacija_vozila pk_lokacija_vozila 
   CONSTRAINT     `   ALTER TABLE ONLY public.lokacija_vozila
    ADD CONSTRAINT pk_lokacija_vozila PRIMARY KEY (id);
 L   ALTER TABLE ONLY public.lokacija_vozila DROP CONSTRAINT pk_lokacija_vozila;
       public            postgres    false    223            �           2606    24984 .   Dodjela_vozila fk_Dodjela_vozila_id_uposlenika    FK CONSTRAINT     �   ALTER TABLE ONLY public."Dodjela_vozila"
    ADD CONSTRAINT "fk_Dodjela_vozila_id_uposlenika" FOREIGN KEY (id_uposlenika) REFERENCES public."Uposlenik"(id_uposlenik) ON DELETE CASCADE;
 \   ALTER TABLE ONLY public."Dodjela_vozila" DROP CONSTRAINT "fk_Dodjela_vozila_id_uposlenika";
       public          postgres    false    233    225    3239            �           2606    24989 *   Dodjela_vozila fk_Dodjela_vozila_id_vozila    FK CONSTRAINT     �   ALTER TABLE ONLY public."Dodjela_vozila"
    ADD CONSTRAINT "fk_Dodjela_vozila_id_vozila" FOREIGN KEY (id_vozila) REFERENCES public."Vozilo"(id_vozila) ON DELETE CASCADE;
 X   ALTER TABLE ONLY public."Dodjela_vozila" DROP CONSTRAINT "fk_Dodjela_vozila_id_vozila";
       public          postgres    false    233    215    3229            �           2606    24964 %   Model_vozila fk_Model_vozila_id_marke    FK CONSTRAINT     �   ALTER TABLE ONLY public."Model_vozila"
    ADD CONSTRAINT "fk_Model_vozila_id_marke" FOREIGN KEY (id_marke) REFERENCES public."Marka"(id) ON DELETE CASCADE;
 S   ALTER TABLE ONLY public."Model_vozila" DROP CONSTRAINT "fk_Model_vozila_id_marke";
       public          postgres    false    219    3233    221            �           2606    24979 :   Uposlenik_kategorija fk_Uposlenik_kategorija_id_kategorije    FK CONSTRAINT     �   ALTER TABLE ONLY public."Uposlenik_kategorija"
    ADD CONSTRAINT "fk_Uposlenik_kategorija_id_kategorije" FOREIGN KEY (id_kategorije) REFERENCES public."Kategorija"(id_kategorije) ON DELETE CASCADE;
 h   ALTER TABLE ONLY public."Uposlenik_kategorija" DROP CONSTRAINT "fk_Uposlenik_kategorija_id_kategorije";
       public          postgres    false    231    229    3243            �           2606    24974 9   Uposlenik_kategorija fk_Uposlenik_kategorija_id_uposlenik    FK CONSTRAINT     �   ALTER TABLE ONLY public."Uposlenik_kategorija"
    ADD CONSTRAINT "fk_Uposlenik_kategorija_id_uposlenik" FOREIGN KEY (id_uposlenik) REFERENCES public."Uposlenik"(id_uposlenik) ON DELETE CASCADE;
 g   ALTER TABLE ONLY public."Uposlenik_kategorija" DROP CONSTRAINT "fk_Uposlenik_kategorija_id_uposlenik";
       public          postgres    false    3239    225    231            �           2606    24969 "   Uposlenik fk_Uposlenik_pozicija_id    FK CONSTRAINT     �   ALTER TABLE ONLY public."Uposlenik"
    ADD CONSTRAINT "fk_Uposlenik_pozicija_id" FOREIGN KEY (pozicija_id) REFERENCES public."Pozicija"(pozicija_id) ON DELETE CASCADE;
 P   ALTER TABLE ONLY public."Uposlenik" DROP CONSTRAINT "fk_Uposlenik_pozicija_id";
       public          postgres    false    227    3241    225            �           2606    24959    Vozilo fk_Vozilo_id_lokacije    FK CONSTRAINT     �   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT "fk_Vozilo_id_lokacije" FOREIGN KEY (id_lokacije) REFERENCES public.lokacija_vozila(id) ON DELETE CASCADE;
 J   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT "fk_Vozilo_id_lokacije";
       public          postgres    false    223    3237    215            �           2606    24949    Vozilo fk_Vozilo_model_vozila    FK CONSTRAINT     �   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT "fk_Vozilo_model_vozila" FOREIGN KEY (model_vozila) REFERENCES public."Model_vozila"(id) ON DELETE CASCADE;
 K   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT "fk_Vozilo_model_vozila";
       public          postgres    false    215    3235    221            �           2606    24954    Vozilo fk_Vozilo_vrsta_vozila    FK CONSTRAINT     �   ALTER TABLE ONLY public."Vozilo"
    ADD CONSTRAINT "fk_Vozilo_vrsta_vozila" FOREIGN KEY (vrsta_vozila) REFERENCES public."Vrsta_vozila"(vrsta_id) ON DELETE CASCADE;
 K   ALTER TABLE ONLY public."Vozilo" DROP CONSTRAINT "fk_Vozilo_vrsta_vozila";
       public          postgres    false    217    3231    215            Z   �   x�M�;1Dk���F����	�l�2��WY-����<�Br��e�I�2�����x��ҏS���5E!ó�ZA%ó4��V���,}<Ck�dx�j��:g�+�tm`�����]�Xd�޾7	m�����Nnj�0�~�hFSD      V   �   x�]�=NA�k�>"�S� E""B�����N��_�w��\$U�^�d�Q�ٟ�����U6㾷��u�l;>|:���]:�x0����`�Kh`�,^�:x��
%�)����+Xqp6�~����;x��li)�rC�tv���P���x�2q��GQ�vvR�����lZl�!����&��iL��s;��_�>��6+�⼂0�O��� m�w�      L   k   x�˻
�@���I�D-c!6�H����"��.b�ޜ��x;3A��L��6���V��񁏞����Y���.�a&q�P�f��g��Y��0�z��3����N���      N   d   x��K
�0������(y�M�rA��I).�~ω�Q�|y����]�mc�U�~��6�&��3i��ۇY���*ּS��BeUxĠ�M�7      T   �   x�M�;�0Dk�)rD�S"�F DI��Vؘ���I�Rp.B�܋�����Li�$Χ 03�c���	��QB-ت^(�ĆU.�	��q�C~!�~�Պ��8�L֦B�.�EL����1;��F�H���	���nLy�D�PN͡���֞
��L ��Cm      R   V  x�m�;j�@�zt��A˾]R���&]�ŤX9��b|�\,��z)`�,��1�%)x���|)�?�����G]R�X�C�ۡ��/�u��t�,�c�y����O��y��%�4U351�A����t�����8�$�6�ܣQ2��H3�r'��l����[+��A�%l6�u-��>�y�\�v��p�q��5z��X)����5�MXĐ��aSn�	�/�_��0��{�JKm�:��{�G�QŻké�����
*x�����Hh���]N5QU���������&p�D.B�oB��ۡ��wC2?0�����vجozE/I�!���W��      X   8   x����0��7UL�u|����A=�)�J��b�dꋥl�r8��ի�z�'�21      H   c  x�e��n�0Eף��Ù�kI���J1�زb!5P#�A�E�>dktQ���̽Ԡa�c�F��s�²Q�XT�����h�_.���矿�w��8-��[��k�aP�:�����P�t�|y�a}_����aN����:�Ea�!��/P��Ӆ�����C�G�֝����&E���bD(�5ٯ�?��ϯ����O����/R�v�m�Fu��ce��|�sð]�	���KCbkTjK(dF_�;ԁ��~��f$�]��8��?�Rf覢�N�F�Iy���*���Fr�}��?6A:�#�iXĨ�/F��1��E�����&"F�R�[#�튓
dnw}����ه�      J   r   x�3�t,-���O���2���/�O����2��N�����2�'�s�r�%f��q�q:e�U�sg���qYpz��&erYr��f�e���TH��lh�\�_TR��,���� wm)�      P   i   x�3�JL/JM�2�.��,�2���J�N�2��/��L�JR���8Js��9�.�LJ�����t)M*�/�-9����K���24��N,��/KL����� ;'Q     