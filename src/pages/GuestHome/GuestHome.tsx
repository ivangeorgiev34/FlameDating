import React from "react";
import styles from "../GuestHome/GuestHome.module.scss";
import { useInView, useSpring } from "@react-spring/web";
import { Footer } from "../../components/layout/footer/Footer";
import { animated } from "@react-spring/web";
import { Link } from "react-router-dom";

export const GuestHome: React.FC = () => {
  const [ref, inView] = useInView();
  const [props, api] = useSpring(() => ({
    from: {
      opacity: 0,
    },
    to: {
      opacity: 1,
    },
    config: {
      duration: 2000,
    },
  }));

  return (
    <React.Fragment>
      <div className={styles.imageContainer}>
        <section className={styles.joinUsContainer}>
          <h1>Start chatting now</h1>
          <p>
            Start meeting new people now near you! Join us for free, or consider
            loggin in if you already have an account!
          </p>
          <div className={styles.btnsContainer}>
            <Link to={"/register"} className={styles.registerBtn}>
              Register here!
            </Link>
            <Link to={"/login"} className={styles.loginBtn}>
              Log in!
            </Link>
          </div>
        </section>
      </div>
      <div className={styles.testiomanialsWrapper}>
        <h2>Meet some of the many satisfied people who used our app!</h2>
        <section className={styles.testiomanials}>
          <animated.div
            ref={ref}
            style={inView === true ? props : undefined}
            className={styles.testiomanialCard}
          >
            <img
              src="william-and-emma.jpg"
              alt="william-and-emma"
              className={styles.testiomanialImage}
            />
            <h3>William and Emma</h3>
            <hr />
            <p>
              After a few dates and a few fun nights out, I met Emma. When I
              read her profile, I couldn't help but like her after her last
              sentence: "Looking for my lifelong super sweet." After texting for
              about a week, we went on our first date and I knew there was
              something special about her!
            </p>
          </animated.div>
          <animated.div
            ref={ref}
            style={inView === true ? props : undefined}
            className={styles.testiomanialCard}
          >
            <img
              src="olivia-and-david.jpg"
              alt="olivia-and-david"
              className={styles.testiomanialImage}
            />
            <h3>Olivia and David</h3>
            <hr />
            <p>
              To be honest, I had gone on too many FlameDating dates and was
              absolutely sure it was a non-committal thing to eat for no money
              and have fun… 3 years now a whole bunch of dates and memories
              later and I am married to my man from FlameDating, David!
            </p>
          </animated.div>
          <animated.div
            ref={ref}
            style={inView === true ? props : undefined}
            className={styles.testiomanialCard}
          >
            <img
              src="lucy.jpg"
              alt="lucy"
              className={styles.testiomanialImage}
            />
            <h3>Lucy</h3>
            <hr />
            <p>
              To all singles out there, especially introverts like us: don't be
              afraid to step outside your comfort zone. That's where you'll make
              a real connection. Tinder brought us together and I am eternally
              grateful for that.
            </p>
          </animated.div>
        </section>
      </div>
      <Footer />
    </React.Fragment>
  );
};
