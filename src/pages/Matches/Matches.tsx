import React, { useEffect, useState } from "react";
import styles from "./Matches.module.scss";
import { getUserSuggestedMatches } from "../../services/matchesService/matchesService";
import { useAppDispatch, useAppSelector } from "../../hooks/reduxHooks";
import ISuggestedMatch from "../../interfaces/matches/ISuggestedMatch";
import { toggleLoaderOff, toggleLoaderOn } from "../../store/loader";
import { Link, useNavigate } from "react-router-dom";
import { TinderCard } from "../../components/TinderCard/TinderCard";
import { useSpring, animated } from "@react-spring/web";

export const Matches: React.FC = () => {
  const { token } = useAppSelector((state) => state.auth);
  const { isLoading } = useAppSelector((state) => state.loader);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const [matches, setMatches] = useState<ISuggestedMatch[]>([]);

  const [noMatchesProps] = useSpring(() => ({
    from: {
      opacity: 0,
    },
    to: {
      opacity: 1,
    },
    config: {
      duration: 700,
    },
  }));

  useEffect(() => {
    dispatch(toggleLoaderOn());

    setMatches([]);

    getUserSuggestedMatches(token!)
      .then((response) => {
        if (response.status === "Error") {
          navigate("/unauthorized");
        } else if (response.status === "Success") {
          setMatches((matches) => [...matches, ...response.content.matches]);
        }
      })
      .catch(() => {
        navigate("/unauthorized");
      })
      .finally(() => {
        dispatch(toggleLoaderOff());
      });
  }, []);

  return (
    <div className={styles.matchesWrapper}>
      {isLoading === false ? (
        matches.length === 0 ? (
          <animated.div
            style={noMatchesProps}
            className={styles.noMatchesMessageContainer}
          >
            <p className={styles.noMatchesMessage}>
              Sorry, but we cannot suggest you any people at this moment!
            </p>
            <Link className={styles.backToHomeBtn} to={"/"}>
              Back to home
            </Link>
          </animated.div>
        ) : (
          matches.map((match) => {
            return <TinderCard key={match.id} {...match} />;
          })
        )
      ) : (
        <></>
      )}
    </div>
  );
};
