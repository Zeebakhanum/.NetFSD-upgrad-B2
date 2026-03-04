INSERT INTO UserInfo VALUES
('admin@gmail.com', 'AdminUser', 'Admin', 'admin123'),
('user1@gmail.com', 'Ravi', 'Participant', 'ravi123');

use EventDb

INSERT INTO UserInfo VALUES
('admin@gmail.com', 'AdminUser', 'Admin', 'admin123'),
('user1@gmail.com', 'Ravi', 'Participant', 'ravi123');

USE EventDb

INSERT INTO EventDetails VALUES
(1, 'Tech Conference', 'Technology', '2026-04-10', 'Annual Tech Event', 'Active');

USE EventDb

INSERT INTO SpeakersDetails VALUES
(101, 'John Smith');

USE EventDb

INSERT INTO SessionInfo VALUES
(201, 1, 'AI Future', 101, 'AI Discussion',
 '2026-04-10 10:00:00',
 '2026-04-10 11:00:00',
 'https://meetlink.com/ai');

 USE EventDb

 INSERT INTO ParticipantEventDetails VALUES
(1, 'user1@gmail.com', 1, 201, 1);

USE EventDb

SELECT * FROM EventDetails;
USE EventDb

select * from ParticipantEventDetails;

select * from SessionInfo;