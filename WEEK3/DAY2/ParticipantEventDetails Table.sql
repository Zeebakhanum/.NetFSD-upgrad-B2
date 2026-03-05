use EventDb

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL,

    CONSTRAINT FK_Participant_User
        FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Participant_Event
        FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Participant_Session
        FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);