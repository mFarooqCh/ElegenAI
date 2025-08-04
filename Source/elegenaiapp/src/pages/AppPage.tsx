import PromptInput from '../components/PromptInput';
import styles from './AppPage.module.css';

const AppPage = () => {
  return (
    <div className={styles.container}>
      <main className={styles.main}>
        <h1 className={styles.heading}>AI Models</h1>
        <PromptInput />
      </main>
    </div>
  );
};

export default AppPage;
