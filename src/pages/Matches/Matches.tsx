import React, { useEffect, useState } from "react";
import styles from "./Matches.module.scss";
import { getUserSuggestedMatches } from "../../services/matchesService/matchesService";
import { useAppDispatch, useAppSelector } from "../../hooks/reduxHooks";
import ISuggestedMatch from "../../interfaces/matches/ISuggestedMatch";
import { toggleLoaderOff, toggleLoaderOn } from "../../store/loader";
import { useNavigate } from "react-router-dom";
import { TinderCard } from "../../components/TinderCard/TinderCard";

export const Matches: React.FC = () => {
  const { token } = useAppSelector((state) => state.auth);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const [matches, setMatches] = useState<ISuggestedMatch[]>([]);

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
      {matches.map((match) => {
        return <TinderCard key={match.id} {...match} />;
      })}
    </div>
  );
};
