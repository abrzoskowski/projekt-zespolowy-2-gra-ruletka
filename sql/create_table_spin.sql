CREATE TABLE roulette.spin
(
    id serial NOT NULL,
    player_name character varying NOT NULL,
    date timestamp with time zone NOT NULL,
    "number" smallint NOT NULL,
    post_account_status real NOT NULL,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
);

ALTER TABLE roulette.spin
    OWNER to postgres;

COMMENT ON TABLE roulette.spin
    IS 'będziemy przechowywać:
-ID zakręcenia,
-nazwę gracza,
-datę zakręcenia,
-wylosowaną liczbę,
-stan konta po operacji';