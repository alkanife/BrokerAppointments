use agenda;
go

INSERT INTO brokers (LastName,FirstName,Mail,PhoneNumber)
VALUES
  ('Crawford','Skyler','diam.pellentesque@aol.edu','0122788718'),
  ('Dickson','Cooper','elit.pharetra.ut@aol.org','0231160244'),
  ('Delaney','Ingrid','quis.urna.nunc@hotmail.net','0401671829'),
  ('Moody','Jenna','varius@hotmail.couk','0435217534'),
  ('Holcomb','Neil','pede.nec.ante@protonmail.ca','0671461853'),
  ('Peterson','Tyrone','elit.curabitur@yahoo.com','0248899150'),
  ('Serrano','Olympia','orci.lacus@yahoo.ca','0308242185'),
  ('Baxter','Kennan','neque@aol.ca','0975784348'),
  ('Harmon','Timon','nam.interdum.enim@protonmail.edu','0854853683'),
  ('Dominguez','James','justo.proin@protonmail.com','0762492242'),
  ('Patterson','Valentine','mi.enim@protonmail.net','0852424674'),
  ('Hendrix','Chava','felis@yahoo.ca','0949426857'),
  ('Hurst','Adrian','in.ornare@google.edu','0536335585'),
  ('Mcfadden','Chadwick','felis.eget@outlook.com','0761965411'),
  ('Richmond','Abraham','ac.ipsum@protonmail.com','0637265290'),
  ('Travis','Serena','porttitor@google.ca','0655104826'),
  ('Adams','Blaze','nunc@aol.edu','0364526703'),
  ('Small','Travis','sed@google.org','0358021254'),
  ('Petty','Charlotte','diam.lorem@hotmail.com','0545428397'),
  ('Daniel','Hedwig','metus@google.org','0565482429');

INSERT INTO customers (LastName,FirstName,Mail,PhoneNumber,Budget)
VALUES
  ('Holloway','Bernard','mollis.lectus.pede@icloud.ca','0289224865',738),
  ('Briggs','Candace','nunc.sed@yahoo.org','0867747762',3578),
  ('Byrd','Elvis','nisl.quisque@aol.ca','0318882222',4867),
  ('Deleon','Chaim','pede.ultrices.a@protonmail.com','0775870084',1440),
  ('Peters','Hunter','odio@aol.com','0494821581',2295),
  ('Raymond','Hedwig','facilisi.sed.neque@google.net','0788682527',3603),
  ('Dillard','Rhiannon','volutpat@google.org','0126777523',653),
  ('Norman','Cedric','mi@google.couk','0828955800',6587),
  ('Osborn','Darryl','ut.tincidunt@google.org','0724159514',8978),
  ('Rowland','Ethan','risus.odio.auctor@aol.com','0549493384',3186),
  ('Small','Orlando','in.hendrerit@icloud.com','0258331982',8070),
  ('Merrill','Isaac','turpis@hotmail.com','0792500797',8130),
  ('Bruce','Dora','eros.non.enim@yahoo.edu','0726445725',6401),
  ('Lancaster','Ali','quisque@hotmail.edu','0671610484',6887),
  ('Woods','Aristotle','aliquet@google.com','0501450046',2920),
  ('Witt','Xander','sapien@google.com','0746487971',3044),
  ('Graham','Melinda','orci.luctus.et@yahoo.couk','0858751874',2751),
  ('Wong','Skyler','fermentum.risus@yahoo.edu','0707609737',3250),
  ('Hubbard','Lillith','vulputate.eu@hotmail.couk','0479719276',9715),
  ('Hudson','Wade','a.auctor@google.edu','0381347957',4340),
  ('York','Judith','nunc.pulvinar@yahoo.com','0447732844',5177),
  ('Davidson','Keane','donec@hotmail.org','0702681524',5246),
  ('Barr','Kermit','nunc.in@aol.ca','0951319441',462),
  ('Garner','Gregory','nunc.quis.arcu@outlook.couk','0916450260',1466),
  ('Wall','Tobias','nam.ac.nulla@aol.org','0514992169',9592),
  ('Preston','Chloe','tristique.pellentesque@aol.net','0142659374',6852),
  ('Leonard','Vivien','et.malesuada@yahoo.com','0245872825',7949),
  ('Merritt','Shelly','elit.erat@icloud.couk','0432037783',7708),
  ('Shaw','Elmo','elit.etiam@outlook.net','0417155085',732),
  ('Hudson','William','quis.pede@icloud.net','0524586709',8777),
  ('Wyatt','Germaine','feugiat.tellus.lorem@yahoo.ca','0557691235',1669),
  ('Poole','Amity','auctor.mauris.vel@protonmail.org','0876123475',1555),
  ('Parks','Nissim','vulputate.lacus@outlook.com','0815141388',2574),
  ('Finch','Lev','rutrum.urna.nec@yahoo.com','0383850581',1923),
  ('Rogers','Kyla','volutpat.nulla@protonmail.ca','0884541671',3622),
  ('Roach','Kirsten','at.pretium.aliquet@outlook.couk','0665501462',9892),
  ('Castro','Whilemina','fringilla.cursus.purus@yahoo.net','0455339932',3180),
  ('Hurley','Delilah','eros.nec@protonmail.com','0846142860',8912),
  ('Buck','Damon','cursus@yahoo.couk','0915682213',7085),
  ('Silva','Xavier','lorem.eu@protonmail.org','0473684221',9340),
  ('Sanchez','Baxter','sociis@hotmail.couk','0463786558',4358),
  ('Moran','Sigourney','non.feugiat@protonmail.edu','0321468311',2887),
  ('Mathis','Maggie','et.commodo@hotmail.com','0540867733',588),
  ('Clemons','Sonia','morbi.sit.amet@hotmail.com','0320487218',7714),
  ('Crosby','Abdul','mauris@hotmail.com','0638156782',6250),
  ('Horne','Yolanda','fringilla.porttitor@icloud.couk','0709563526',5349),
  ('Marks','Lillian','rutrum.non@yahoo.ca','0571807201',1571),
  ('Schwartz','April','augue.ac@yahoo.net','0253585118',9877),
  ('Jenkins','Vivian','turpis.vitae@hotmail.com','0487156481',4707),
  ('Roy','Scott','diam@hotmail.com','0277245680',821),
  ('Bryan','Zia','morbi@aol.ca','0821958382',5776),
  ('Ross','Tanya','nunc@yahoo.ca','0771772213',3984),
  ('Greene','Keith','magna@icloud.com','0205221914',6883),
  ('Jensen','Ali','scelerisque.scelerisque.dui@google.couk','0781023287',7029),
  ('Harris','Grady','ipsum.donec@outlook.com','0572284105',9214),
  ('Mack','Hayfa','lorem.ipsum@aol.org','0618448574',3720),
  ('Hayden','Vivian','nisi.magna@hotmail.edu','0378426165',4547),
  ('Page','Brooke','donec.non.justo@protonmail.org','0206165441',7410),
  ('Mathis','Reed','et.tristique@icloud.edu','0910645189',2471),
  ('Kramer','Russell','feugiat@icloud.net','0384363682',1071),
  ('Rosales','Colton','nullam.suscipit@icloud.ca','0346202583',9536),
  ('Langley','Colby','accumsan.sed@icloud.com','0404146827',5242),
  ('Manning','Evelyn','duis.at.lacus@hotmail.ca','0362941221',5483),
  ('Hinton','Brock','elit.pharetra.ut@aol.org','0787744731',4593),
  ('Burns','Flynn','gravida@protonmail.org','0283184479',9965),
  ('Foley','Ray','felis.nulla.tempor@aol.com','0311456747',5408),
  ('Mercado','Jorden','semper.dui.lectus@protonmail.ca','0853673218',7776),
  ('Rogers','Ayanna','eu.eleifend@icloud.net','0826647574',7321),
  ('Pitts','Trevor','nullam.feugiat.placerat@hotmail.com','0331844275',4298),
  ('Chang','Josiah','egestas.a@outlook.net','0784968642',9226),
  ('Norton','Cullen','donec.felis@yahoo.ca','0331871424',453),
  ('Patel','Ebony','non.justo.proin@aol.ca','0832653725',7364),
  ('Joyce','Ella','in.tincidunt.congue@outlook.ca','0627345255',8693),
  ('Chang','Kamal','aliquam.ornare.libero@icloud.couk','0692853702',1657),
  ('Nieves','Tara','egestas.hendrerit@icloud.com','0212675178',8292),
  ('Lloyd','Beau','sagittis.lobortis.mauris@icloud.edu','0472676135',7036),
  ('Wolfe','Steel','urna@aol.org','0957558305',9107),
  ('Burch','Burke','nulla.magna@aol.edu','0575725123',1723),
  ('Bentley','Todd','ridiculus@google.net','0418253325',2214),
  ('Oneal','Asher','non.dui@protonmail.edu','0617147869',6687),
  ('Wilcox','Zena','natoque.penatibus.et@protonmail.ca','0251755608',1826),
  ('Rios','Carlos','aliquam.ultrices@protonmail.org','0728313853',5155),
  ('Eaton','Amir','donec.est@hotmail.com','0944764843',7514),
  ('Marshall','Pascale','malesuada.integer@aol.net','0638911064',5343),
  ('Lowery','Slade','egestas.fusce.aliquet@aol.edu','0896411164',9582),
  ('Fleming','Alisa','elit.pharetra@hotmail.org','0232214733',9319),
  ('Cooper','Sheila','at@protonmail.org','0304965440',5414),
  ('Leonard','Heidi','nulla@yahoo.couk','0425643225',556),
  ('Reed','Darius','purus@aol.couk','0812321352',7767),
  ('Buckner','Edan','arcu.curabitur.ut@aol.com','0718617362',5866),
  ('Trevino','Brianna','at.pede.cras@outlook.com','0971178850',7796),
  ('Carson','Lev','vulputate.risus@outlook.edu','0843820511',4931),
  ('William','Ruth','risus.duis@outlook.net','0615773874',7181),
  ('Lane','Jermaine','et@protonmail.net','0808203653',9505),
  ('David','Nero','tempor.diam.dictum@icloud.net','0532127146',9378),
  ('Flowers','Lewis','vestibulum@google.net','0462555187',7677),
  ('Simon','Chancellor','arcu@yahoo.ca','0238865136',8207),
  ('Kidd','Tyrone','erat@icloud.org','0227636339',1297),
  ('Manning','Bethany','quam.quis@hotmail.com','0493006688',3909),
  ('Sawyer','Dieter','dictum.augue.malesuada@google.org','0617078472',5582);


INSERT INTO appointements (DateHour,Subject,BrokerId,CustomerId)
VALUES
  ('2023-7-15','placerat eget, venenatis a, magna. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam laoreet, libero et tristique pellentesque, tellus',25,22),
  ('2024-6-10','dui, in sodales elit erat vitae risus. Duis a mi fringilla mi lacinia mattis. Integer eu lacus. Quisque imperdiet, erat',17,46),
  ('2022-9-10','senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit.',18,70),
  ('2022-11-22','nonummy ipsum non arcu. Vivamus sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc est, mollis',25,40),
  ('2023-7-17','nonummy ac, feugiat non, lobortis quis, pede. Suspendisse dui. Fusce diam nunc, ullamcorper eu, euismod ac, fermentum vel, mauris. Integer',7,43),
  ('2023-5-17','aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et',12,100),
  ('2022-8-10','nibh. Quisque nonummy ipsum non arcu. Vivamus sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc',22,57),
  ('2023-9-2','egestas. Fusce aliquet magna a neque. Nullam ut nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam',17,25),
  ('2022-11-9','tristique pharetra. Quisque ac libero nec ligula consectetuer rhoncus. Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque',8,33),
  ('2022-7-14','Fusce aliquet magna a neque. Nullam ut nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam ultrices',17,42),
  ('2023-8-6','nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque',23,35),
  ('2024-6-17','ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis',16,75),
  ('2024-4-4','Curabitur dictum. Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris sit amet lorem semper auctor. Mauris vel',14,84),
  ('2023-11-24','Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis quis, pede. Suspendisse dui. Fusce',14,73),
  ('2022-9-8','Cras sed leo. Cras vehicula aliquet libero. Integer in magna. Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed, est.',12,49),
  ('2023-5-31','magna. Praesent interdum ligula eu enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac facilisis',9,59),
  ('2023-8-17','Morbi sit amet massa. Quisque porttitor eros nec tellus. Nunc lectus pede, ultrices a, auctor non, feugiat nec, diam. Duis',25,86),
  ('2024-3-18','magnis dis parturient montes, nascetur ridiculus mus. Aenean eget magna. Suspendisse tristique neque venenatis lacus. Etiam bibendum fermentum metus. Aenean',15,104),
  ('2023-9-27','nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non',23,23),
  ('2024-4-24','faucibus ut, nulla. Cras eu tellus eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan',24,85),
  ('2024-5-4','quis diam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce aliquet magna a neque.',15,81),
  ('2022-8-9','eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis natoque penatibus et magnis dis parturient montes,',11,33),
  ('2023-11-11','Nullam suscipit, est ac facilisis facilisis, magna tellus faucibus leo, in lobortis tellus justo sit amet nulla. Donec non justo.',10,39),
  ('2024-6-21','Nulla eget metus eu erat semper rutrum. Fusce dolor quam, elementum at, egestas a, scelerisque sed, sapien. Nunc pulvinar arcu',21,66),
  ('2024-1-28','urna et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum',14,54),
  ('2023-3-4','at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod',18,92),
  ('2023-10-6','augue ac ipsum. Phasellus vitae mauris sit amet lorem semper auctor. Mauris vel turpis. Aliquam adipiscing lobortis risus. In mi',20,21),
  ('2023-4-8','lorem, auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat',19,97),
  ('2023-6-22','non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis quis, pede. Suspendisse dui. Fusce diam nunc, ullamcorper eu, euismod',18,72),
  ('2022-8-1','auctor. Mauris vel turpis. Aliquam adipiscing lobortis risus. In mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean euismod',11,42);

