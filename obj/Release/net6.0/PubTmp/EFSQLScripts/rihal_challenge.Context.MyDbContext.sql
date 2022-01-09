IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220104104802_init')
BEGIN
    CREATE TABLE [class_table] (
        [ClassId] uniqueidentifier NOT NULL,
        [ClassName] nvarchar(max) NULL,
        CONSTRAINT [PK_class_table] PRIMARY KEY ([ClassId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220104104802_init')
BEGIN
    CREATE TABLE [country_table] (
        [CountryId] uniqueidentifier NOT NULL,
        [CountryName] nvarchar(max) NULL,
        CONSTRAINT [PK_country_table] PRIMARY KEY ([CountryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220104104802_init')
BEGIN
    CREATE TABLE [student_table] (
        [StudentId] uniqueidentifier NOT NULL,
        [StudentName] nvarchar(max) NULL,
        [StudentDateOfBirth] datetime2 NOT NULL,
        [CountryId] uniqueidentifier NOT NULL,
        [ClassId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_student_table] PRIMARY KEY ([StudentId]),
        CONSTRAINT [FK_student_table_class_table_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [class_table] ([ClassId]) ON DELETE CASCADE,
        CONSTRAINT [FK_student_table_country_table_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [country_table] ([CountryId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220104104802_init')
BEGIN
    CREATE INDEX [IX_student_table_ClassId] ON [student_table] ([ClassId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220104104802_init')
BEGIN
    CREATE INDEX [IX_student_table_CountryId] ON [student_table] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220104104802_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220104104802_init', N'6.0.1');
END;
GO

COMMIT;
GO

