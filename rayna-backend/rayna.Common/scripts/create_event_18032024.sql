CREATE TABLE Event (
    EventId SERIAL PRIMARY KEY,
    Name VARCHAR(1024),
    SubTitle VARCHAR(1024),
    SupplierId INT NOT NULL,
    CountryId INT NOT NULL,
    StateId INT NOT NULL,
    CityId INT NOT NULL,
    InventoryId INT NOT NULL, -- DTCM, Rayna inventory
    TypeId INT NOT NULL, -- Location Based, Online, sporting
    CategoryId INT NOT NULL, -- Desi, Nightlife, Popular, Concerts
    CurrencyId INT NOT NULL,
    FromDateTime TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    ToDateTime TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    Description VARCHAR(1024),
    Status INT NOT NULL,
    CreatedDate TIMESTAMP WITHOUT TIME ZONE,
    CreatedBy INT,
    UpdatedDate TIMESTAMP WITHOUT TIME ZONE,
    UpdatedBy INT
);
CREATE SCHEMA IF NOT EXISTS logging;

CREATE TABLE Logging.APILogs (
    Id BIGSERIAL PRIMARY KEY,
    Method VARCHAR(20),
    Host VARCHAR(255),
    Path VARCHAR(255),
    StatusCode INT,
    RequestAt TIMESTAMP WITH TIME ZONE,
    ResponseAt TIMESTAMP WITH TIME ZONE,
    QueryString TEXT,
    RequestBody TEXT,
    ResponseBody TEXT,
    Exception TEXT
);