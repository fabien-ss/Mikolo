-- marque
INSERT INTO marque (id, label) VALUES
                                   ('M1', 'Dell'),
                                   ('M2', 'HP'),
                                   ('M3', 'Apple'),
                                   ('M4', 'Lenovo');

-- reference
INSERT INTO reference (id, id_marque, label) VALUES
                                                 ('R1', 'M1', 'Dell XPS 13'),
                                                 ('R2', 'M2', 'HP Spectre x360'),
                                                 ('R3', 'M3', 'MacBook Pro'),
                                                 ('R4', 'M4', 'Lenovo ThinkPad X1 Carbon');

-- processeur
INSERT INTO processeur (id, label, frequence, coeur, gravure) VALUES
                                                                  ('P1', 'Intel Core i5', 2.4, 4, 14),
                                                                  ('P2', 'Intel Core i7', 2.8, 6, 14),
                                                                  ('P3', 'AMD Ryzen 5', 3.2, 6, 7),
                                                                  ('P4', 'AMD Ryzen 7', 3.6, 8, 7);

-- ram
INSERT INTO ram (id, label, puissance) VALUES
                                           ('RAM1', '8GB DDR4', 8),
                                           ('RAM2', '16GB DDR4', 16),
                                           ('RAM3', '32GB DDR4', 32);

-- disque_dur
INSERT INTO disque_dur (id, label, stockage, rotation, taille) VALUES
                                                                   ('DD1', '256GB SSD', 256, 7200, 2.5),
                                                                   ('DD2', '512GB SSD', 512, 5400, 2.5),
                                                                   ('DD3', '1TB SSD', 1024, 7200, 2.5);

-- ecran
INSERT INTO ecran (id, label, taille) VALUES
                                          ('E1', 'Full HD 13"', 13),
                                          ('E2', '4K UHD 15.6"', 15.6),
                                          ('E3', 'Retina 16"', 16);

-- laptop
-- Exemple d'insertion de 40 laptops avec des données aléatoires
-- Vous devrez ajuster les valeurs selon vos besoins

DO $$
    DECLARE
        i INT := 1;
    BEGIN
        WHILE i <= 40 LOOP
                INSERT INTO laptop (id_reference, id_processeur, id_ram, id_ecran, id_disque_dur)
                VALUES
                    ((SELECT id FROM reference ORDER BY random() LIMIT 1),
                     (SELECT id FROM processeur ORDER BY random() LIMIT 1),
                     (SELECT id FROM ram ORDER BY random() LIMIT 1),
                     (SELECT id FROM ecran ORDER BY random() LIMIT 1),
                     (SELECT id FROM disque_dur ORDER BY random() LIMIT 1));
                i := i + 1;
            END LOOP;
    END $$;
