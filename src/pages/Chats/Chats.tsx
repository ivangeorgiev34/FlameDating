import React, { useEffect, useState } from "react";
import styles from "./Chats.module.scss";
import IChat from "../../interfaces/chats/IChat";
import { getUsersChats } from "../../services/chatService/chatService";
import { useAppDispatch, useAppSelector } from "../../hooks/reduxHooks";
import { useNavigate } from "react-router-dom";
import { toggleLoaderOff, toggleLoaderOn } from "../../store/loader";

export const Chats: React.FC = () => {
  const [chats, setChats] = useState<IChat[]>([]);

  const { token } = useAppSelector((selector) => selector.auth);
  const dispatch = useAppDispatch();

  const navigate = useNavigate();

  useEffect(() => {
    dispatch(toggleLoaderOn());

    getUsersChats(token!)
      .then((response) => {
        if (response.status === "Error") {
          navigate("/not-found");
        } else if (response.status === "Success") {
          setChats(() => response.content.chats);
        }
      })
      .catch(() => {
        navigate("/internal-server-error");
      })
      .finally(() => {
        dispatch(toggleLoaderOff());
      });
  }, []);

  return (
    <>{chats.length === 0 ? <div>no chats</div> : <div>{chats.length}</div>}</>
  );
};
