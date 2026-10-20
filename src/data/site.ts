import type { ImageMetadata } from 'astro';
import statementSense from '../assets/statementsense.png';
import signWiz from '../assets/signwiz.png';

export const site = {
  name: 'David Edwards',
  role: 'Application Software Engineer',
  description:
    'David Edwards is an Application Software Engineer at Permobil, building iOS and Android apps for connected medical devices and running the CI/CD behind them.',
  email_form_key: '531b77bc-241a-46ac-8296-6dffab1cbdc7', // Web3Forms public access key
  github: 'https://github.com/davidedwards-12',
  linkedin: 'https://www.linkedin.com/in/davidmedwards12',
};

export interface Role {
  title: string;
  org: string;
  dates: string;
  summary?: string;
  points: string[];
}

export const experience: Role[] = [
  {
    title: 'Application Software Engineer',
    org: 'Permobil',
    dates: 'Dec 2025 – Present',
    points: [
      'Core member of the Application Team on new product development, designing and delivering features for the iOS and Android apps alongside the embedded software team, in a regulated medical device environment.',
      'Own end-to-end testing and validation, enforcing the quality gates that releases have to pass before production.',
      "Write and maintain the CI/CD pipeline scripts and YAML configuration behind the team's automated builds.",
      "Administer the self-hosted Mac build servers that the team's build pipelines depend on.",
    ],
  },
  {
    title: 'Engineer Intern',
    org: 'Permobil',
    dates: 'Mar 2025 – Dec 2025',
    points: [
      'Led a month-long shakedown test for a new product, managing a four-person team and earning leadership recognition.',
      'Built a Python/HTML dashboard that tracks device and OS updates so compatibility testing can start ahead of releases.',
      'Shipped feature enhancements to the iOS and Android apps and tested legacy and new mobile products for validation.',
    ],
  },
  {
    title: 'Test Engineer',
    org: 'Amazon Robotics',
    dates: 'Oct 2024 – Jan 2025',
    points: [
      'Operated and maintained Proteus and Cardinal warehouse robots, diagnosing faults such as immobile drives, battery issues and package jams.',
      'Documented unusual robot behavior to feed reliability improvements back into the system.',
    ],
  },
  {
    title: 'B.S. in Computing, Computer Science concentration',
    org: 'East Tennessee State University',
    dates: 'Graduated 2024',
    summary: "Dean's List, Fall 2021 and Fall 2023.",
    points: [],
  },
];

export const toolbox: { label: string; items: string[] }[] = [
  { label: 'Languages', items: ['Swift', 'Kotlin', 'C#', 'Java', 'Python'] },
  { label: 'Platforms', items: ['iOS', 'Android', 'Linux/Unix'] },
  { label: 'Delivery', items: ['CI/CD pipelines', 'Automated testing', 'GitHub', 'Scrum'] },
];

export interface Project {
  name: string;
  kind: string;
  blurb: string;
  stack: string[];
  repo?: string;
  image?: ImageMetadata;
  imageAlt?: string;
}

export const featured: Project = {
  name: 'StatementSense',
  kind: 'Native iOS app',
  blurb:
    'Import bank statement PDFs and get a clear picture of your finances. StatementSense parses statements from multiple banks, auto-categorizes transactions, and shows monthly spending breakdowns, income vs. expenses, and savings rate.',
  stack: ['Swift', 'SwiftUI', 'SwiftData', 'PDFKit', 'Swift Charts'],
  repo: 'https://github.com/davidedwards-12/budget-calc-app-ios',
  image: statementSense,
  imageAlt: 'StatementSense dashboard showing income, expenses, savings rate and a category breakdown chart',
};

export const projects: Project[] = [
  {
    name: 'SignWiz',
    kind: 'Web app',
    blurb: 'An educational app for learning sign language through quizzes and interactive games.',
    stack: ['C#', 'ASP.NET', 'JavaScript', 'HTML/CSS'],
    repo: 'https://github.com/davidedwards-12/SignWizApp',
    image: signWiz,
    imageAlt: 'SignWiz home page',
  },
  {
    name: 'This site',
    kind: 'Portfolio',
    blurb:
      'Designed and built by me. A static, single-page site with no client-side JavaScript, optimized images and self-hosted fonts.',
    stack: ['Astro', 'TypeScript', 'CSS'],
    repo: 'https://github.com/davidedwards-12/MyPortfolio',
  },
];

// Unannounced project: shown as a redacted teaser card.
export const teaser = { name: 'Project Shift-eze', status: 'In development' };
