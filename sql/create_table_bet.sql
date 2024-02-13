CREATE TABLE roulette.bet
(
    spin_id integer NOT NULL,
    bet_id character varying NOT NULL,
    bet_price real NOT NULL,
    CONSTRAINT fk FOREIGN KEY (spin_id)
        REFERENCES roulette.spin (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
);

ALTER TABLE roulette.bet
    OWNER to postgres;