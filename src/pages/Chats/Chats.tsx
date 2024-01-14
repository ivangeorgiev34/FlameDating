import React, { useEffect, useState } from "react";
import styles from "./Chats.module.scss";
import IChat from "../../interfaces/chats/IChat";

export const Chats: React.FC = () => {
  const [chats, setChats] = useState<IChat[]>([]);

  return <div>chats</div>;
};
