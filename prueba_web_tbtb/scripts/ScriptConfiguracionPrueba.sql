use heroku_140c3c145dfa13e;
CREATE TABLE `worker` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `username` VARCHAR(100) NOT NULL,
    `email` VARCHAR(100)  NOT NULL,
    `addressId` INTEGER NOT NULL,
    `phone` VARCHAR(30)  NOT NULL,
    `website` VARCHAR(100)  NOT NULL,
    `companyId` INTEGER NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `address` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `street` VARCHAR(100) NOT NULL,
    `suit` VARCHAR(100)  NOT NULL,
    `city` VARCHAR(100) NOT NULL,
    `zipcode` VARCHAR(100) NOT NULL,
    `lat` VARCHAR(100) NOT NULL,
    `long` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `company` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(100) NOT NULL,
    `catchPhrase` VARCHAR(300)  NOT NULL,
    `bs` VARCHAR(300) NOT NULL,
    PRIMARY KEY (`id`)
);

ALTER TABLE `worker` ADD FOREIGN KEY (`addressId`) REFERENCES `address`(`id`) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE `worker` ADD FOREIGN KEY (`companyId`) REFERENCES `company`(`id`) ON DELETE CASCADE ON UPDATE CASCADE;
