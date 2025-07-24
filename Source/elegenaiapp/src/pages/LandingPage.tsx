import styles from './LandingPage.module.css';

const LandingPage = () => {
  return (
    <main className={styles.container}>
      <h1 className={styles.title}>Welcome to ElegenAI</h1>
      <p className={styles.subtitle}>
        Turn your images and words into smart, AI-generated captions instantly.
      </p>
      <a href="/app" className={styles.ctaButton}>
        Get Started
      </a>
    </main>
  );
};

export default LandingPage;
